using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public class EventDispatcherAttribute : Attribute
    {
        public int[] ids;
        public EventDispatcherAttribute(EventType eventType)
        {
            ids = new int[] { (int)eventType };
        }
        public EventDispatcherAttribute(EventType eventType, EventType eventType1)
        {
            ids = new int[] { (int)eventType, (int)eventType1 };
        }
        public EventDispatcherAttribute(EventType eventType, EventType eventType1, EventType eventType2)
        {
            ids = new int[] { (int)eventType, (int)eventType1, (int)eventType2 };
        }
    }
}
