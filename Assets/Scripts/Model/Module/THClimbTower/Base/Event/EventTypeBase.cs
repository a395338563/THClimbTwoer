using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public class EventDispatcherAttribute : Attribute
    {
        public int SortIndex;
        public int[] ids;
        public EventDispatcherAttribute(EventType eventType,int SortIndex=0)
        {
            ids = new int[] { (int)eventType };
            this.SortIndex = SortIndex;
        }
        public EventDispatcherAttribute(EventType eventType, EventType eventType1,int SortIndex= 0)
        {
            ids = new int[] { (int)eventType, (int)eventType1 };
            this.SortIndex = SortIndex;
        }
        public EventDispatcherAttribute(EventType eventType, EventType eventType1, EventType eventType2, int SortIndex = 0)
        {
            ids = new int[] { (int)eventType, (int)eventType1, (int)eventType2 };
            this.SortIndex = SortIndex;
        }
        public EventDispatcherAttribute(EventType eventType, EventType eventType1, EventType eventType2, EventType eventType3, int SortIndex = 0)
        {
            ids = new int[] { (int)eventType, (int)eventType1, (int)eventType2, (int)eventType3 };
            this.SortIndex = SortIndex;
        }
        public EventDispatcherAttribute(int eventType, int SortIndex = 0)
        {
            ids = new int[] { eventType };
            this.SortIndex = SortIndex;
        }
        public EventDispatcherAttribute(int eventType, int eventType1, int SortIndex = 0)
        {
            ids = new int[] { eventType, eventType1 };
            this.SortIndex = SortIndex;
        }
        public EventDispatcherAttribute(int eventType, int eventType1, int eventType2, int SortIndex = 0)
        {
            ids = new int[] { eventType, eventType1, eventType2 };
            this.SortIndex = SortIndex;
        }
        public EventDispatcherAttribute(int eventType, int eventType1, int eventType2, int eventType3, int SortIndex = 0)
        {
            ids = new int[] { eventType, eventType1, eventType2, eventType3 };
            this.SortIndex = SortIndex;
        }
    }
}
