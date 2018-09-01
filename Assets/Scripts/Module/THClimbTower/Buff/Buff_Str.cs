using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    [EventWatcher(new EventType[] { EventType.GetCardDesc, EventType.GetPlayerCardDesc })]
    public class Buff_Str : Buff
    {
        public override async Task<object> RunEvent(EventType eventType, object o, params object[] args)
        {
            Card card = o as Card;
            card.Damage += LastTime;
            return card;
        }
    }
}
