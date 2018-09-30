using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower.BaseEvent
{
    [EventDispatcher(EventType.BattleStart)]
    public class BattleStart : iEventDispatcher<EnemyTeam>
    {
        public void Handle(EventType eventType, EnemyTeam enemyTeam)
        {
            EventSystem.Instance.RunEvent(EventType.BattleStart);
            EventSystem.Instance.RunEvent(EventType.PlayerTurnStart);
        }

        void BattleInit()
        {
            Battle battle = Game.Instance.NowBattle;
            
        }
    }
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
