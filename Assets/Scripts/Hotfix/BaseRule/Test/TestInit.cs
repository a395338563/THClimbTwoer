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
    [EventDispatcher(EventType.GameStart)]
    public class TestInit : THClimbTower.iEventDispatcher
    {
        public void Handle(EventType eventType)
        {
            Player player = THClimbTower.Game.Instance.player;
            player.MaxHp = 100;
            player.NowHp = 100;
            player.Gold = 2333;
            player.MainCharactorType = CharactorTypeEnum.Reimu;
            for (int i = 0; i < 5; i++)
            {
                player.Deck.Add(CardFactory.Instance.Get(CardEnum.TestAttack) as AbstractPlayerCard);
                player.Deck.Add(CardFactory.Instance.Get(CardEnum.TestDefence) as AbstractPlayerCard);
            }
            player.potions.Add(new Potion.TestPotion());
            //player.AddRelics(new TestRelic());
        }
    }

    [BaseEvent(1000)]
    [EventDispatcher(EventType.TestBattle)]
    public class TestBattle : iEventDispatcher
    {
        public void Handle(EventType eventType)
        {
            Log.Debug("生成测试战斗");
            THClimbTower.Game.Instance.player = new Player();
            Player player = THClimbTower.Game.Instance.player;
            player.MaxHp = 100;
            player.NowHp = 100;
            player.Gold = 2333;
            player.MainCharactorType = CharactorTypeEnum.Reimu;
            for (int i = 0; i < 5; i++)
            {
                player.Deck.Add(CardFactory.Instance.Get(CardEnum.TestAttack) as AbstractPlayerCard);
                player.Deck.Add(CardFactory.Instance.Get(CardEnum.TestDefence) as AbstractPlayerCard);
            }
            player.potions.Add(new Potion.TestPotion());

            THClimbTower.Game.Instance.NowBattle = new Battle();
            THClimbTower.EventSystem.Instance.RunEvent(EventType.BattleStart, EnemyTeamFactory.Instance.Get(EnemyTeam.EnemyTeamEnum.TestTeam));
            //THClimbTower.Game.Instance.NowBattle.StartBattle(EnemyTeamFactory.Instance.Get(EnemyTeam.EnemyTeamEnum.TestTeam));
        }
    }
}
