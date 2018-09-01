using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public abstract class Buff : Model.Component,iEventWatcher
    {
        public int LastTime { get; set; }

        public Charactor Owner
        {
            get
            {
                return Parent as Charactor;
            }
        }
        public abstract Task<object> RunEvent(EventType eventType, object o, params object[] args);
    }
}
