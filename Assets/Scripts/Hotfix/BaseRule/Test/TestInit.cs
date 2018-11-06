using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotfix.Card;
using Model;
using THClimbTower;

namespace Hotfix.BaseRule
{
    /*[EventDispatcher(EventType.GameStart)]
    public class TestInit : THClimbTower.iEventDispatcher
    {
        public int SortIndex => 0;

        public void Handle(EventType eventType, params object[] param)
        {
            Player player = THClimbTower.Game.Instance.player;
            player.MaxHp = 100;
            player.NowHp = 100;
            player.Gold = 2333;
            //player.MainCharactorType = CharactorTypeEnum.Alice;
            player.AddCard(CardEnum.TestAttack, 5);
            player.AddCard(CardEnum.TestDefence, 5);
            player.potions.Add(new Potion.TestPotion());
        }
    }

    [BaseEvent(1000)]
    [EventDispatcher(EventType.TestGame)]
    public class TestBattle : iEventDispatcher
    {
        public int SortIndex => 0;

        public void Handle(EventType eventType, params object[] param)
        {
            Log.Debug("生成测试战斗");
            THClimbTower.Game.Instance.player = new Player();
            Player player = THClimbTower.Game.Instance.player;
            player.MaxHp = 100;
            player.NowHp = 100;
            player.Gold = 2333;
            player.AddCard(CardEnum.TestAttack, 5);
            player.AddCard(CardEnum.TestDefence, 5);
            player.potions.Add(new Potion.TestPotion());

            Map map= THClimbTower.Game.Instance.NowMap = new Map();
            //map.Creat(0, 10, 5, 6);

            //THClimbTower.Game.Instance.NowBattle = new Battle();
            //THClimbTower.EventSystem.Instance.RunEvent(EventType.BattleStart, EnemyTeamFactory.Instance.Get(EnemyTeam.EnemyTeamEnum.TestTeam));
            //THClimbTower.Game.Instance.NowBattle.StartBattle(EnemyTeamFactory.Instance.Get(EnemyTeam.EnemyTeamEnum.TestTeam));
        }
    }*/
}
