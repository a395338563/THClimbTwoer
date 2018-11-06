using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THClimbTower;

namespace Hotfix.Buff
{
    [EventDispatcher(EventType.GetCardFinalInfo)]
    public class Buff_Str : AbstractBuff,iEventDispatcher
    {
        public override string Icon { get; } = "str";

        public int SortIndex => 0;

        public void Handle(EventType eventType, params object[] param)
        {
            (param[0] as AbstractCard).Damage += Amount;
        }
    }
}
