using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public enum EventType
    {
        testEventType,
        GetCardDesc,
        BattleStart,
        PlayerTurnStart,
        EnemyTurnStart,
        PlayerTurnEnd,
        BeforeDamageTake,
        OnDamageTake,
        BattleEnd,
    }
}
