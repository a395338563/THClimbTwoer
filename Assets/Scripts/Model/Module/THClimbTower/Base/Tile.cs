using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using UnityEngine;

namespace THClimbTower
{
    public class Tile : BaseConfig, IComparable
    {
        public virtual TileTypeEnum Type => TileTypeEnum.Other;
        public int X { get; internal set; }
        public int Y { get; internal set; }
        public TileStatusEnum tileStatus { get; internal set; }
        internal SortedSet<Tile> Pres = new SortedSet<Tile>(), Nexts = new SortedSet<Tile>();

        public HashSet<Tile> GetNexts()
        {
            return new HashSet<Tile>(Nexts);
        }

        public int CompareTo(object obj)
        {
            int y = Y.CompareTo((obj as Tile).Y);
            if (y == 0) return X.CompareTo((obj as Tile).X);
            return y;
        }
        /*public Vector2 pos()
        {
            return new Vector2(X * 200, Y * 100 + 500);
        }*/

        internal virtual void OnEnter()
        {
            
        }
        internal virtual Tile Init()
        {
            return this;
        }
        /*public virtual void ShowDeltaInfo()
        {
            EventSystem.Instance.RunEvent(EventType.ShowDeltaInfo, this);
        }*/

        internal void Enter()
        {
            tileStatus = TileStatusEnum.OnTile;
            Game.Instance.EventSystem.Call(EventType.FreshMap, Game.Instance.NowMap);
            OnEnter();
            //tileStatus = TileStatusEnum.Complete;
            //Game.Instance.EventSystem.Call(EventType.FreshMap, Game.Instance.NowMap);
        }

        public enum TileStatusEnum
        {
            CanEnter,
            NotEnter,
            OnTile,
            Complete,
        }

        public enum TileTypeEnum
        {
            Treasure,
            Battle_Sp,
            Battle,
            Rest,
            Shop,
            Event,
            Boss,

            Other = 100,
        }
    }

    public class TileAttribute : BaseConfigAttribute
    {
        /*public TileAttribute(string Id)
        {
            this.Id = Id;
        }*/
        public TileAttribute(Tile.TileTypeEnum Id) : base()
        {
            this.Id = (int)Id;
        }
    }

    public class TileFactory : BaseFactory<Tile, TileAttribute>
    {
        public static TileFactory Instance
        {
            get
            {
                return instance == null ? instance = new TileFactory() : instance;
            }
        }
        private static TileFactory instance;

        public Tile Get(Tile.TileTypeEnum tileType)
        {
            return Get((int)tileType);
        }
    }
}

