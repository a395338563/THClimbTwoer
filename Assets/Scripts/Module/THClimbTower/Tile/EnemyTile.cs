using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    /// <summary>
    /// 进入此格时，进行战斗
    /// </summary>
    public class EnemyTile : Tile
    {
        public override void OnClick()
        {
            Game.Instance.NowBattle = new Battle();
            //ETModel.EnemyTeamConfig enemyTeamConfig = ETModel.Game.Scene.GetComponent<ETModel.ConfigComponent>().GetCategory(typeof(ETModel.EnemyTeamConfig)).TryGet(1002) as ETModel.EnemyTeamConfig;

            //Game.Instance.NowBattle.StartBattle(enemyTeamConfig);
        }
    }
}
