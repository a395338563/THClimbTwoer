using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THClimbTower;

namespace THClimbTower
{
    /// <summary>
    /// 普通小怪战斗
    /// </summary>
    public class BattleTile:Tile
    {
        public override TileTypeEnum Type => TileTypeEnum.Battle;
        public int Diffcult;
        internal override void OnEnter()
        {
            EnemyTeamConfig teamConfig = EnemyTeamFactory.Instance.Get(999);
            Game.Instance.EventSystem.Call(EventType.BattleStart, teamConfig);
            //Game.Instance.player.ReciveDamage(new DamageInfo() { Damage = 10, Type = DamageInfo.DamageTypeEnum.Hit });
            //Game.Instance.player.Gold += 10;
        }
    }
}
