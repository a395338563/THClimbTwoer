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
    public class BattleStart : iEventDispatcher
    {
        public int SortIndex => 0;

        public void Handle(EventType eventType, params object[] param)
        {
            BattleInit(param[0] as EnemyTeamConfig);
            Game.Instance.EventSystem.Call(EventType.PlayerTurnStart);
        }

        void BattleInit(EnemyTeamConfig enemyTeam)
        {
            Model.Log.Debug("战斗初始化");
            Battle battle = Game.Instance.NowBattle;
            battle.Deck.Clear();
            battle.Hand.Clear();
            battle.Cemetery.Clear();
            battle.Gap.Clear();
            //battle.player = Game.Instance.player;
            battle.Enemys.Clear();
            for (int i = 0; i < enemyTeam.Team.Length; i++)
            {
                int Id = enemyTeam.Team[i];
                AbstractEnemy e = EnemyFatory.Instance.Get(Id);
                e.X = enemyTeam.Pos[i].x;
                e.Y = enemyTeam.Pos[i].y;
                battle.Enemys.Add(e);
            }
            battle.Turn = 0;

            foreach (AbstractPlayerCard p in battle.player.GetDeck())
            {
                battle.Deck.Add(p);
            }
        }
    }
    [BaseEvent(1004)]
    [EventDispatcher(EventType.PlayerTurnEnd)]
    public class PlayerTurnEnd : iEventDispatcher
    {
        public int SortIndex => 0;

        public void Handle(EventType eventType, params object[] param)
        {
            Game.Instance.EventSystem.Call(EventType.EnemyTurnStart);
            //怪物行动的时候战斗结束，那么就不要开始玩家回合了
            //if (!Game.Instance.NowBattle.GameEnd)
            //    Game.Instance.EventSystem.Call(EventType.PlayerTurnStart);
        }
    }   
}
