using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public abstract class AbstractBuff : Model.Component
    {
        public int Amount { get; set; }

        public abstract string Icon { get; }

        public AbstractCharactor Owner { get; set; }
        //public abstract Task<object> RunEvent(EventType eventType, object o, params object[] args);
    }
}
