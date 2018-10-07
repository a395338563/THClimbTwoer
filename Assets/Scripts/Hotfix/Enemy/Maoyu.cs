using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotfix.EnemyCard;
using THClimbTower;

namespace Hotfix.Enemy
{
    [Enemy(EnemyEnum.Maoyu)]
    public class Maoyu : AbstractEnemy
    {
        public override string Name
        {
            get
            {
                return "Maoyu";
            }
        }

        protected override AbstractEnemyCard AIThink()
        {
            return new MaoyuHit() { BaseDamage = 15, BaseHits = 1 };
        }
        public override void EnenmyInit()
        {
            MaxHp = NowHp = 10;
        }
    }
}
