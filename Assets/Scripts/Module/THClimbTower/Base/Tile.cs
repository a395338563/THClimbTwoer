using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public class Tile : Model.Entity
    {
        public TileTypeEnum TileType;
        public int Level;
        public List<Tile> Next = new List<Tile>();
        public virtual void OnClick()
        {
            Model.Log.Debug("you click a default tile");
        }
        public enum TileTypeEnum
        {
            Default,
            Enemy,
            Enemy_Sp,
            Boss,
            Event,
            Shop,
            StartShop,
            Camp,
            Box,
        }
    }
    public static class TileFactory
    {
        public static Tile Creat(Tile.TileTypeEnum type)
        {
            Tile output;
            switch (type)
            {
                case Tile.TileTypeEnum.Enemy:
                    output= new EnemyTile() ;
                    break;
                default:
                    output = new Tile();
                    break;
            }
            output.TileType = type;
            return output;
        }
        public static Tile CreatRandom()
        {
            return new Tile();
        }
    }
}
