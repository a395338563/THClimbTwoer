using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public class DamageInfo
    {
        public int Damage;
        public DamageTypeEnum Type;
        public enum DamageTypeEnum
        {
            Hit,
        }
    }
}
