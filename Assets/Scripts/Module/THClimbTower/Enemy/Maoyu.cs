using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    [Enemy(EnemyEnum.Maoyu)]
    public class Maoyu : Enemy
    {
        public override string Name
        {
            get
            {
                return "Maoyu";
            }
        }

        protected override EnemyCard AIThink()
        {
            return new MaoyuHit() { BaseDamage = 15, BaseHits = 1 };
        }
        public override void EnenmyInit()
        {
            MaxHp = NowHp = 10;
        }
    }
}
