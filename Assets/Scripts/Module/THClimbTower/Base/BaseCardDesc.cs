using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{    
    [EventDispatcher(EventType.GetCardDesc)]
    public class BaseCardDescFirst : iEventDispatcher<Card,BattleCharactor,BattleCharactor>
    {
        /*public void Handle(BaseEvent baseEvent)
        {
            Card Card;
            BattleCharactor user;
            BattleCharactor reciver;
            if (baseEvent is Event_GetCardDesc)
            {
                (baseEvent as Event_GetCardDesc).GetParams(out Card, out user, out reciver);
                Card.Damage = Card.BaseDamage;
                Card.Armor = Card.BaseArmor;
                Card.Hits = Card.BaseHits;
            }
        }*/

        public void Handle(EventType baseEvent, Card t, BattleCharactor t1, BattleCharactor t2)
        {
            if (baseEvent == EventType.GetCardDesc)
            {
                t.Damage = t.BaseDamage;
                t.Armor = t.BaseArmor;
                t.Hits = t.BaseHits;
            }
        }
    }
    [EventDispatcher(EventType.GetCardDesc)]
    public class BaseCardDescFinal : iEventDispatcher<Card, BattleCharactor, BattleCharactor>
    {
        public void Handle(EventType baseEvent, Card t, BattleCharactor t1, BattleCharactor t2)
        {
            if (baseEvent == EventType. GetCardDesc)
            {
                //(baseEvent as Event_GetCardDesc).GetParams(out Card, out user, out reciver);
                if (t is PlayerCard)
                {
                    PlayerCard playerCard = t as PlayerCard;
                    playerCard.Desc = playerCard.BaseDesc.Replace("$Damage$", playerCard.Damage.ToString());
                    playerCard.Desc = playerCard.Desc.Replace("$Hits$", playerCard.Hits.ToString());
                    playerCard.Desc = playerCard.Desc.Replace("$Armor$", playerCard.Armor.ToString());
                }
            }
        }
    }
   [EventDispatcher(EventType.BattleEnd)]
    public class CheckBattleEnd : iEventDispatcher
    {

        public void Handle(EventType baseEvent)
        {
            throw new NotImplementedException();
        }
    }
}
