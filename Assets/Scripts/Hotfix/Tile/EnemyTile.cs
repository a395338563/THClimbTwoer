using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using THClimbTower;

namespace Hotfix
{
    /// <summary>
    /// 进入此格时，进行战斗
    /// </summary>
    [Tile(TileTypeEnum.Enemy)]
    public class EnemyTile : Tile
    {
        public override void OnClick()
        {
            THClimbTower.Game.Instance.NowBattle = new Battle();
            Model.Game.Scene.GetComponent<UIManagerComponent>().LoadSence(UIViewType.Battle);
            //ETModel.EnemyTeamConfig enemyTeamConfig = ETModel.Game.Scene.GetComponent<ETModel.ConfigComponent>().GetCategory(typeof(ETModel.EnemyTeamConfig)).TryGet(1002) as ETModel.EnemyTeamConfig;

            //Game.Instance.NowBattle.StartBattle(enemyTeamConfig);
        }
    }
}
