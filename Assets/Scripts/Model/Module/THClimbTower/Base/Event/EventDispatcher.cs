using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public interface iEventDispatcher
    {
        int SortIndex { get; }
        void Handle(EventType eventType,params object[] param);
    }
}
