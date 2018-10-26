using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THClimbTower;

namespace Hotfix.BaseRule
{
    [BaseEvent(1003)]
    [EventDispatcher(EventType.BattleStart)]
    public class BattleStart : iEventDispatcher<EnemyTeamConfig>
    {
        public void Handle(EventType eventType, EnemyTeamConfig enemyTeam)
        {
            BattleInit(enemyTeam);
            EventSystem.Instance.RunEvent(EventType.PlayerTurnStart);
        }

        void BattleInit(EnemyTeamConfig enemyTeam)
        {
            Model.Log.Debug("战斗初始化");
            Battle battle = Game.Instance.NowBattle;
            battle.Deck = new List<AbstractPlayerCard>();
            battle.Hand = new List<AbstractPlayerCard>();
            battle.Cemetery = new List<AbstractPlayerCard>();
            battle.Gap = new List<AbstractPlayerCard>();
            battle.player = Game.Instance.player;
            battle.Enemys = new List<AbstractEnemy>();
            for (int i = 0; i < enemyTeam.Team.Length; i++)
            {
                int Id = enemyTeam.Team[i];
                AbstractEnemy e = EnemyFatory.Instance.Get(Id);
                e.X = enemyTeam.Pos[i].x;
                e.Y = enemyTeam.Pos[i].x;
                battle.Enemys.Add(e);
            }
            battle.Turn = 0;
            battle.GameEnd = false;

            foreach (AbstractPlayerCard p in battle.player.Deck)
            {
                battle.Deck.Add(p);
            }
        }
    }
    [BaseEvent(1004)]
    [EventDispatcher(EventType.PlayerTurnEnd)]
    public class PlayerTurnEnd : iEventDispatcher
    {
        public void Handle(EventType eventType)
        {
            EventSystem.Instance.RunEvent(EventType.EnemyTurnStart);
            //怪物行动的时候战斗结束，那么就不要开始玩家回合了
            if (!Game.Instance.NowBattle.GameEnd)
                EventSystem.Instance.RunEvent(EventType.PlayerTurnStart);
        }
    }   
}
