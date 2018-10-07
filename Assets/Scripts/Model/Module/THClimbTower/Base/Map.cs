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
        public int LevelNum, StartLevel, MinLine, MaxLine, MaxHeight, MaxWidth;

        public List<Tile> tiles = new List<Tile>();

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

        public async void CreatAsync(int StartLevel, int height, int width, int Density,int time)
        {
            //int yadd = -1;
            Tile last = null;
            for (int i = 0; i < Density; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    //yadd++;
                    int y = StartLevel + j;
                    //第一层单独
                    if (j == 0)
                    {
                        int x = RandomUtil.Next(0, width + 1);
                        Tile tile = Creat(x, y);
                        last = tile;
                        AddTile(tile);
                        //Log.Debug($"Add Base Tile:{tile.X,tile.Y}");
                    }
                    else
                    {
                        int minX = last.X;
                        int maxX = last.X;
                        if (last.X != 0)
                            minX--;
                        if (last.X != width)
                        {
                            maxX++;
                        }
                        int x = RandomUtil.Next(minX, maxX + 1);
                        int rx = x - last.X;
                        if (rx == -1)
                        {
                            Tile lf = GetLeftTile(last);
                            Log.Debug($"L{x},{lf?.GetMaxXChild()},{lf?.GetInfo()}");
                            if (lf != null && lf.GetMaxXChild() > x)
                            {
                                Log.Debug("Change Max");
                                x = lf.GetMaxXChild();
                            }
                        }
                        if (rx == 1)
                        {
                            Tile lr = GetRightTile(last);
                            Log.Debug($"R{x},{lr?.GetMinXChild()},{lr?.GetInfo()}");
                            if (lr != null && lr.GetMinXChild() < x)
                            {
                                Log.Debug("Change Min");
                                x = lr.GetMinXChild();
                            }
                        }
                        Tile tile = Creat(x, y);
                        if (!last.Next.Contains(tile))
                            last.Next.Add(tile);
                        if (!tile.Parent.Contains(last))
                            tile.Parent.Add(last);
                        last = tile;
                        AddTile(tile);
                    }
                    await Task.Delay(time);
                }
                //int x = RandomUtil.Next();
            }
        }

        public void Creat(int StartLevel, int height, int width, int Density)
        {
            Tile Root = Creat(width / 2, StartLevel - 1);
            AddTile(Root);
            NowTile = Root;
            Tile last = Root;
            for (int i = 0; i < Density; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int y = StartLevel + j;
                    //第一层单独
                    if (j == 0)
                    {
                        int x = RandomUtil.Next(0, width + 1);
                        Tile tile = Creat(x, y);
                        last = tile;
                        AddTile(tile);
                        if (!Root.Next.Contains(tile))
                            Root.Next.Add(tile);
                        if (!tile.Parent.Contains(tile))
                            tile.Parent.Add(Root);
                        //Log.Debug($"Add Base Tile:{tile.X,tile.Y}");
                    }
                    else
                    {
                        int minX = last.X;
                        int maxX = last.X;
                        if (last.X != 0)
                            minX--;
                        if (last.X != width)
                        {
                            maxX++;
                        }
                        int x = RandomUtil.Next(minX, maxX + 1);
                        int rx = x - last.X;
                        if (rx == -1)
                        {
                            Tile lf = GetLeftTile(last);
                            if (lf != null && lf.GetMaxXChild() > x)
                            {
                                x = lf.GetMaxXChild();
                            }
                        }
                        if (rx == 1)
                        {
                            Tile lr = GetRightTile(last);
                            if (lr != null && lr.GetMinXChild() < x)
                            {
                                x = lr.GetMinXChild();
                            }
                        }
                        Tile tile = Creat(x, y);
                        if (!last.Next.Contains(tile))
                            last.Next.Add(tile);
                        if (!tile.Parent.Contains(last))
                            tile.Parent.Add(last);
                        last = tile;
                        AddTile(tile);
                    }
                }
                //int x = RandomUtil.Next();
            }
        }

        Tile GetLeftTile(Tile tile)
        {
            Tile output = null;
            foreach (var t in tiles)
            {
                if (t.Y != tile.Y||t==tile)
                    continue;
                if (t.X < tile.X)
                {
                    if (output == null)
                    {
                        output = t;
                    }
                    else
                    {
                        if (t.X > output.X)
                            output = t;
                    }
                }
            }
            //if (output != null) Log.Debug($"{tile.X},{tile.Y} Left is {output.X},{output.Y}");
            return output;
        }
        Tile GetRightTile(Tile tile)
        {
            Tile output = null;
            foreach (var t in tiles)
            {
                if (t.Y != tile.Y||t==tile)
                    continue;
                if (t.X > tile.X)
                {
                    if (output == null)
                    {
                        output = t;
                    }
                    else
                    {
                        if (t.X < output.X)
                            output = t;
                    }
                }
            }
            //if (output != null) Log.Debug($"{tile.X},{tile.Y} Right is {output.X},{output.Y}");
            return output;
        }

        void AddTile(Tile tile)
        {
            if (!tiles.Contains(tile))
            {
                tiles.Add(tile);
            }
        }

        Tile Creat(int x,int y)
        {
            foreach (var tile in tiles)
            {
                if (tile.X == x && tile.Y == y)
                    return tile;
            }
            Tile t = TileFactory.Instance.Get(Tile.TileTypeEnum.Enemy);
            t.X = x;
            t.Y = y;
            //Log.Debug($"Creat New Tile{x},{y}");
            return t;
        }

        /*public void Creat(int LevelNum,int StartLevel, int MinLine=3, int MaxLine=6)
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
                int num = RandomUtil.Next(MinLine, MaxLine + 1);
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
                        int r = RandomUtil.Next(0, Count);
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
                        int r = RandomUtil.Next(0, Count);
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
        }*/
    }
    public enum MapThemeEnum
    {
        HXM,
        YYM,
    }
}
