using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    [EventWatcher(new EventType[] { EventType.GetCardDesc,EventType.GetPlayerCardDesc },-1)]
    public class BaseCardDescFirst : Model.Component,iEventWatcher
    {
        public async Task<object> RunEvent(EventType eventType, object o, params object[] args)
        {
            Card card = o as Card;
            card.Damage = card.BaseDamage;
            card.Armor = card.BaseArmor;
            card.Hits = card.BaseHits;
            return card;
        }
    }
    [EventWatcher(new EventType[] { EventType.GetPlayerCardDesc },100)]
    public class BaseCardDescFinal : Model.Component, iEventWatcher
    {
        public async Task<object> RunEvent(EventType eventType, object o, params object[] args)
        {
            PlayerCard card = o as PlayerCard;
            card.Desc = card.BaseDesc.Replace("$Damage$", card.Damage.ToString());
            card.Desc = card.Desc.Replace("$Hits$", card.Hits.ToString());
            card.Desc = card.Desc.Replace("$Armor$", card.Armor.ToString());
            return card;
        }
    }

    [EventWatcher(new EventType[] { EventType.Die })]
    public class CheckBattleEnd : Model.Component, iEventWatcher
    {
        public async Task<object> RunEvent(EventType eventType, object o, params object[] args)
        {
            Game.Instance.NowBattle.CheckWin();
            return o;
        }
    }
}
