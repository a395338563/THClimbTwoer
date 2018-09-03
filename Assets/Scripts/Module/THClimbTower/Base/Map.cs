using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public class Map : Model.Entity
    {
        public int LevelNum, StartLevel, MinLine, MaxLine, MaxHeight, MaxWidth;

        public List<Tile> tiles;

        Tile NowTile;

        public void GoNextTile(Tile tile)
        {
            if (NowTile.Next.Contains(tile))
            {
                tile.OnClick();
                NowTile = tile;
            }
            else
            {
                Model.Log.Info("you can't go this tile");
            }
        }

        public void Creat(int LevelNum,int StartLevel, int MinLine=3, int MaxLine=5)
        {
            tiles = new List<Tile>();
            List<Tile> last,now=new List<Tile>();
            for (int i = 0; i < LevelNum; i++)
            {
                //第0层固定为特殊商店
                if (i == 0)
                {
                    Tile t = TileFactory.Creat(Tile.TileTypeEnum.StartShop);
                    t.Level = StartLevel;
                    now.Add(t);
                    tiles.Add(t);
                    //从第0层开始游戏
                    NowTile = t;
                    continue;
                }
                //最终层固定为boss
                if (i == LevelNum - 1)
                {
                    Tile t = TileFactory.Creat(Tile.TileTypeEnum.Boss);
                    t.Level = StartLevel + i;
                    tiles.Add(t);
                    foreach (var tile in now)
                    {
                        tile.Next.Add(t);
                    }
                    continue;
                }
                last = now;
                now = new List<Tile>();
                //生成本层节点
                int num = Game.Instance.RandomSeed.Next(MinLine, MaxLine + 1);
                for (int j = 0; j < num; j++)
                {
                    Tile t = TileFactory.CreatRandom();
                    t.Level = StartLevel + i;
                    now.Add(t);
                    tiles.Add(t);
                }
                //上层节点和本层节点连接
                if (now.Count > last.Count)
                {
                    int Count = now.Count - last.Count;
                    int[] ex = new int[last.Count];
                    for (int j = 0; j < ex.Length; j++)
                    {
                        //丑陋的生成代码
                        if (j == ex.Length - 1)
                        {
                            ex[ex.Length - 1] = Count;
                            continue;
                        }
                        int r = Game.Instance.RandomSeed.Next(0, Count);
                        Count -= r;
                        ex[j] = r;
                    }
                    Count = 0;
                    for (int j = 0; j < ex.Length; j++)
                    {
                        for(int m = 0; m < ex[j] + 1; m++)
                        {
                            last[j].Next.Add(now[m + Count]);
                        }
                        Count += ex[j]+1;
                    }
                }
                else
                {
                    int Count = last.Count - now.Count;
                    int[] ex = new int[now.Count];
                    for (int j = 0; j < ex.Length; j++)
                    {
                        if (j == ex.Length - 1)
                        {
                            ex[ex.Length - 1] = Count;
                            continue;
                        }
                        int r = Game.Instance.RandomSeed.Next(0, Count);
                        Count -= r;
                        ex[j] = r;
                    }
                    Count = 0;
                    for (int j = 0; j < ex.Length; j++)
                    {
                        for (int m = 0; m < ex[j] + 1; m++)
                        {
                            last[m + Count].Next.Add(now[j]);
                        }
                        Count += ex[j]+1;
                    }
                }               
            }
        }
    }
    public enum MapThemeEnum
    {
        HXM,
        YYM,
    }
}
