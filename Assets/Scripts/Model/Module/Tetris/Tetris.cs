using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public struct Point2
    {
        public int x, y;
    }

    public class Cell
    {
        public bool Full;
    }

    public class World
    {
        /// <summary>
        /// 分数
        /// </summary>
        public int Source;
        public Cell[,] cells;
        /// <summary>
        /// 正在下掉的方块和下一个会生产的方块
        /// </summary>
        public Tile Now,Next;

        /// <summary>
        /// 开始一局新游戏
        /// </summary>
        public void StartNexGame()
        {

        }
        /// <summary>
        /// 更新世界状态，推动方块往下掉以及生产新的方块
        /// </summary>
        public void Update()
        {

        }
        /// <summary>
        /// 计算一整行的方块消除
        /// </summary>
        void CheckClear()
        {

        }
        /// <summary>
        /// 判断是否已经失败
        /// </summary>
        void CheckFail()
        {

        }
    }
    public class Tile
    {
        /// <summary>
        /// 方块的形状 锚点默认在(0,0)
        /// </summary>
        public Point2[] Shape;
        /// <summary>
        /// 旋转方块
        /// </summary>
        public bool ChangeShape(World world)
        {
            return true;
        }
    }
}
