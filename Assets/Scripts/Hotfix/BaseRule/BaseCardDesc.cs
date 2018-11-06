using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THClimbTower;

namespace Hotfix.BaseRule
{
    /// <summary>
    /// 初始化卡片基本信息
    /// </summary>
    [BaseEvent(1001)]
    [EventDispatcher(EventType.GetCardFinalInfo)]
    public class BaseCardDescFirst : iEventDispatcher
    {
        public int SortIndex => -100;

        public void Handle(EventType eventType, params object[] param)
        {
            AbstractCard t = param[0] as AbstractCard;
            AbstractCharactor t1 = param[1] as AbstractCharactor;
            AbstractCharactor t2 = param[2] as AbstractCharactor;
            t.Damage = t.BaseDamage;
            t.Armor = t.BaseArmor;
            t.Hits = t.BaseHits;
        }
    }
    /// <summary>
    /// 将卡牌数值套入描述中，让玩家看得懂
    /// </summary>
    [BaseEvent(1002)]
    [EventDispatcher(EventType.GetCardFinalInfo, 100)]
    public class BaseCardDescFinal : iEventDispatcher
    {
        public int SortIndex => 100;

        public void Handle(EventType eventType, params object[] param)
        {
            if (param[0] is AbstractPlayerCard)
            {
                AbstractPlayerCard playerCard = param[0] as AbstractPlayerCard;
                playerCard.Desc = playerCard.BaseDesc.Replace("$Damage$", playerCard.Damage.ToString());
                playerCard.Desc = playerCard.Desc.Replace("$Hits$", playerCard.Hits.ToString());
                playerCard.Desc = playerCard.Desc.Replace("$Armor$", playerCard.Armor.ToString());
            }
        }
    }
}
