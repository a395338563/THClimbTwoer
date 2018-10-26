using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THClimbTower;

namespace Hotfix.Enemy
{
    public partial class EnemyEnum
    {
        public const int TestEnemy = 0;
        public const int Maoyu = 1;
    }

    [Enemy(EnemyEnum.Maoyu)]
    public class Maoyu : AbstractEnemy
    {
        public override string Name => "毛玉";

        protected override AbstractEnemyCard AIThink()
        {
            throw new NotImplementedException();
        }
    }
    [Enemy(EnemyEnum.TestEnemy)]
    public class TestEnemy : AbstractEnemy
    {
        public override string Name => "稻草人";

        protected override AbstractEnemyCard AIThink()
        {
            throw new NotImplementedException();
        }
    }
}
