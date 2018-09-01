using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace THClimbTower
{
    public enum EventType
    {
        test,

        Die,

        GetCardDesc,
        GetPlayerCardDesc,

        BattleStart,
        PlayerTurnStart,
        EnemyTurnStart,
        PlayerTurnEnd,

        BeforeDrawCard,
        AfterDrawCard,

        HpChange,

        BeforeCardUse,
        AfterCardUse,

        BeforeDamageTake,
        OnDamageTake,
    }
}
