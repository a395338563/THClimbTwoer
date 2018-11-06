using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public class RandomUtil
    {
        static Random random = new Random(0);
        static public Random MapRandomSeed;
        static public Random BattleRandomSeed;
        static int Next(int Start,int End)
        {
            return random.Next(Start, End);
        }
       public static void SetSeed(int seed)
        {
            random = new Random(seed);
            MapRandomSeed = new Random(random.Next(0,10000));
            BattleRandomSeed = new Random(random.Next(0, 10000));
        }
    }
}
