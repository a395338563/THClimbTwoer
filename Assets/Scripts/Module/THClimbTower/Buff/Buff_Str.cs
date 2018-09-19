using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    [EventDispatcher(EventType.GetCardDesc)]
    public class Buff_Str : Buff,iEventDispatcher
    {

        public void Handle(EventType baseEvent)
        {
            throw new NotImplementedException();
        }

        /*public override async Task<object> RunEvent(EventType eventType, object o, params object[] args)
        {
            Card card = o as Card;
            card.Damage += LastTime;
            return card;
        }*/
    }
}
