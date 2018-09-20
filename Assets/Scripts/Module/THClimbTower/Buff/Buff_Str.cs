using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower.Buff
{
    [EventDispatcher(EventType.GetCardFinalInfo)]
    public class Buff_Str : AbstractBuff,iEventDispatcher<AbstractCard,AbstractCharactor,AbstractCharactor>
    {
        public override string Icon { get; } = "str";

        public void Handle(EventType eventType, AbstractCard t, AbstractCharactor t1, AbstractCharactor t2)
        {
            t.Damage += Amount;
        }

        /*public override async Task<object> RunEvent(EventType eventType, object o, params object[] args)
        {
            Card card = o as Card;
            card.Damage += LastTime;
            return card;
        }*/
    }
}
