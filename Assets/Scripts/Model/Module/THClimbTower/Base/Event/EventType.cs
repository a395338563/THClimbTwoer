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
        TestBattle,

        GameStart,
        GameEnd,

        /// <summary>
        /// 确定卡片的最终使用信息
        /// </summary>
        GetCardFinalInfo,

        BattleStart,
        PlayerTurnStart,
        EnemyTurnStart,
        PlayerTurnEnd,

        /// <summary>
        /// 一张牌打出前
        /// </summary>
        BeforeCardUse,
        /// <summary>
        /// 一张牌打出后
        /// </summary>
        AfterCardUse,

        /// <summary>
        /// 伤害发生前，可能会被格挡
        /// </summary>
        BeforeDamageTake,
        /// <summary>
        /// 伤害发生时
        /// </summary>
        OnDamageTake,
        BattleEnd,
    }
}
