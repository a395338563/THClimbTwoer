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
    [EventDispatcher(EventType.GetCardFinalInfo,-100)]
    public class BaseCardDescFirst : iEventDispatcher<AbstractCard,AbstractCharactor,AbstractCharactor>
    {
        public void Handle(EventType baseEvent, AbstractCard t, AbstractCharactor t1, AbstractCharactor t2)
        {
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
    public class BaseCardDescFinal : iEventDispatcher<AbstractCard, AbstractCharactor, AbstractCharactor>
    {
        public void Handle(EventType baseEvent, AbstractCard t, AbstractCharactor t1, AbstractCharactor t2)
        {
            if (t is AbstractPlayerCard)
            {
                AbstractPlayerCard playerCard = t as AbstractPlayerCard;
                playerCard.Desc = playerCard.BaseDesc.Replace("$Damage$", playerCard.Damage.ToString());
                playerCard.Desc = playerCard.Desc.Replace("$Hits$", playerCard.Hits.ToString());
                playerCard.Desc = playerCard.Desc.Replace("$Armor$", playerCard.Armor.ToString());
            }
        }
    }
}
