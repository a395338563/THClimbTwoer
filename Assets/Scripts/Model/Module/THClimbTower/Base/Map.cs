using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace THClimbTower
{
    public class Map : Model.Entity
    {
        HashSet<Tile> tiles = new HashSet<Tile>();
        public Tile NowTile { get; private set; }

        public HashSet<Tile> GetTiles()
        {
            return new HashSet<Tile>(tiles);
        }

        public bool CanMove(Tile Next)
        {
            return NowTile.Nexts.Contains(Next);
        }
        public void MoveNext(Tile Next)
        {
            if (!CanMove(Next))
            {
                return;
            }
            NowTile = Next;
            NowTile.Enter();
        }
        public void ReBuild(int MaxLineNumber, int MaxWidth, int Length, int StartLevel)
        {
            /*瞎写的路线生成,估计还得改*/
            for (int i = 0; i < MaxLineNumber; i++)
            {
                //重复i次生成路线
                Tile LastTile = null;
                for (int j = 0; j < Length; j++)
                {
                    Tile next;
                    if (j == 0)
                    {
                        //第零层固定位置生成起点
                        int y = MaxWidth / 2;
                        next = Get(StartLevel, y);
                        if (next == null)
                            next = new StartTile() { X = StartLevel, Y = y };
                        NowTile = next;
                    }
                    else if (j == 1)
                    {
                        //第一层的位置是完全随机的
                        //第一次一定是小怪
                        int y = RandomUtil.MapRandomSeed.Next(0, MaxWidth);
                        next = Get(StartLevel + 1, y);
                        if (next == null)
                            next = new BattleTile() { X = StartLevel + 1, Y = y };
                    }
                    else if (j == Length - 1)
                    {
                        //最后一层固定位置生成boss
                        int y = MaxWidth / 2;
                        next = Get(StartLevel + j, y);
                        if (next == null)
                            next = new BossTile() { X = StartLevel + j, Y = y };
                    }
                    else
                    {
                        //中间层
                        List<int> waychoose = new List<int>() { -1, 0, 1 };
                        if (LastTile.Y == 0) waychoose.Remove(-1);
                        else if (LastTile.Y == MaxWidth - 1) waychoose.Remove(1);
                        Tile midNext = Get(StartLevel + j, LastTile.Y);
                        if (midNext != null)
                        {
                            foreach (Tile t in midNext.Pres)
                            {
                                if (t.Y == midNext.Y + 1)
                                    waychoose.Remove(1);
                                else if (t.Y == midNext.Y - 1)
                                    waychoose.Remove(-1);
                            }
                        }
                        int NextY = LastTile.Y + waychoose[RandomUtil.MapRandomSeed.Next(0, waychoose.Count)];
                        next = Get(StartLevel + j, NextY);
                        //if (next == null)
                        if (j == Length / 2)
                        {
                            next = Get(StartLevel + j, NextY);
                            if (next == null)
                                next = new TreasureTile() { X = StartLevel + j, Y = NextY };
                        }
                        else
                            next = CreatRandom(LastTile.Type, next, StartLevel + j); //new BattleTile() { X = StartLevel + j, Y = NextY };
                        next.X = StartLevel + j;
                        next.Y = NextY;
                    }
                    if (j != 0) LastTile.Nexts.Add(next);
                    next.Pres.Add(LastTile);
                    tiles.Add(next);
                    LastTile = next;
                }
            }

        }

        private Tile CreatTile(Tile.TileTypeEnum type, int Value)
        {
            switch (type)
            {
                case Tile.TileTypeEnum.Battle:
                    return new BattleTile();
                case Tile.TileTypeEnum.Battle_Sp:
                    return new BattleTile_SP();
                case Tile.TileTypeEnum.Treasure:
                    return new TreasureTile();
                case Tile.TileTypeEnum.Rest:
                    return new RestTile();
                case Tile.TileTypeEnum.Shop:
                    return new ShopTile();
                case Tile.TileTypeEnum.Event:
                    return new EventTile();
                case Tile.TileTypeEnum.Boss:
                    return new BossTile();
                default:
                    return null;
            }
        }
        private Tile CreatRandom(Tile.TileTypeEnum lastType, Tile now, int Value)
        {
            //分别是 宝箱,精英,小怪,火堆,商店,事件,boss的概率
            int[] Chance = { 0, 2, 10, 3, 2, 2, 0 };
            if (lastType != Tile.TileTypeEnum.Battle || lastType != Tile.TileTypeEnum.Event)//杂兵和事件可以连着
                Chance[(int)lastType] = 0;
            /*if (NextType != Tile.TileTypeEnum.Other)
                Chance[(int)NextType] = 0;*/
            int sum = 0;
            foreach (var i in Chance) sum += i;
            int ran = RandomUtil.MapRandomSeed.Next(0, sum);
            int index = 0;
            while (Chance[index] <= ran)
            {
                ran -= Chance[index];
                index++;
            }
            Tile result = CreatTile((Tile.TileTypeEnum)index, Value);
            if (now != null)
            {
                result.Nexts = new SortedSet<Tile>(now.Nexts);
                result.Pres = new SortedSet<Tile>(now.Pres);
                tiles.Remove(now);
            }
            return result;
        }

        internal Tile Get(int x, int y)
        {
            Tile tile = tiles.FirstOrDefault((t) =>
            {
                return t.X == x && t.Y == y;
            });
            return tile;
        }
    }
}
