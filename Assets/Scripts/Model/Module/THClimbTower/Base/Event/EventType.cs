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
        TestGame,

        /// <summary>
        /// 通知顶部UI更改玩家信息,参数为Player
        /// </summary>
        PlayerInfoChange,

        /// <summary>
        /// 地图重建,参数为Map
        /// </summary>
        ReBuildMap,
        /// <summary>
        /// 通知UI更改地图状态，参数为Map
        /// </summary>
        FreshMap,

        /// <summary>
        /// 选完人物后初始化完成，游戏开始，参数为玩家选择的主副人物配置AbstractCharactorConfig
        /// </summary>
        GameStart,
        /// <summary>
        /// 游戏结束，无参数(以后可能有)
        /// </summary>
        GameEnd,
        /// <summary>
        /// 玩家的血量发生变化,参数为变化的角色AbstractCharactor和变化数值ValueChange
        /// </summary>
        HpChange,

        /// <summary>
        /// 确定卡片的最终使用信息,参数为卡片Card，使用者AbstractCharactor，承受者AbstractCharactor(可能为空)
        /// </summary>
        GetCardFinalInfo,

        /// <summary>
        /// 玩家金钱发生变化,参数为ValueChange
        /// </summary>
        GoldChange,
        /// <summary>
        /// 战斗开始,参数为怪物配置信息EnemyTeamConfig
        /// </summary>
        BattleStart,
        /// <summary>
        /// 玩家的回合开始，参数为Battle
        /// </summary>
        PlayerTurnStart,
        /// <summary>
        /// 怪物的回合开始,参数为Battle
        /// </summary>
        EnemyTurnStart,
        /// <summary>
        /// 玩家的回合结束
        /// </summary>
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
        /// 伤害发生前，参数为DamagerInfo
        /// </summary>
        BeforeDamageTake,
        /// <summary>
        /// 伤害发生时，参数为DamagerInfo
        /// </summary>
        OnDamageTake,
        BattleEnd,
    }
}
