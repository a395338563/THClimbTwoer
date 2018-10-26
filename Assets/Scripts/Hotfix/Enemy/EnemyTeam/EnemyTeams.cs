using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THClimbTower;
using Hotfix.Enemy;

namespace Hotfix.EnemyTeam
{
    public class EnemyTeamEnum
    {
        public const int TestTeam = 999;

        public const int Maoyu = 1;
    }

    [EnemyTeam(EnemyTeamEnum.TestTeam)]
    public class TestTeam : EnemyTeamConfig
    {
        public override void Init()
        {
            Team = new int[] { EnemyEnum.TestEnemy };
            this.Pos = new UnityEngine.Vector2[] { new UnityEngine.Vector2() };
        }
    }
}
