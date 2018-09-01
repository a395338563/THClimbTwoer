using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public class EventWatcherAttribute:Attribute
    {
        public EventType[] Types;
        public int SortIndex;
        public EventWatcherAttribute(EventType[] Types,int SortIndex = 0)
        {
            this.Types = Types;
            this.SortIndex = SortIndex;
        }
    }
}
