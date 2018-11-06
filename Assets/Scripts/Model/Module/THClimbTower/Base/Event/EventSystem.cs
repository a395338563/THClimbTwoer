using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public class EventSystem
    {
        class SortEvent:IComparable
        {
            public int SortIndex;
            public Action<EventType, object[]> action;

            public SortEvent(int sortIndex, Action<EventType,object[]> action)
            {
                SortIndex = sortIndex;
                this.action = action;
            }

            public int CompareTo(object obj)
            {
                return SortIndex.CompareTo((obj as SortEvent).SortIndex);
            }
        }
        /*public static EventSystem Instance
        {
            get
            {
                return instance == null ? instance = new EventSystem() : instance;
            }
        }
        private static EventSystem instance;*/
        Dictionary<int, SortedSet<SortEvent>> dic = new Dictionary<int, SortedSet<SortEvent>>();
        
        public void Call(EventType eventType,params object[] Params)
        {
            if (dic.ContainsKey((int)eventType))
                foreach (var a in dic[(int)eventType])
                {
                    a.action.Invoke(eventType,Params);
                }
        }

        public void AddDispatcher(iEventDispatcher dispatcher)
        {
            object[] attrs= dispatcher.GetType().GetCustomAttributes(typeof(EventDispatcherAttribute), false);
            foreach (EventDispatcherAttribute e in attrs)
            {
                //Model.Log.Debug(e.ToString());
                foreach (var a in e.ids)
                {
                    SortedSet<SortEvent> eventDispatchers;
                    dic.TryGetValue(a, out eventDispatchers);
                    if (eventDispatchers == null)
                    {
                        eventDispatchers = new SortedSet<SortEvent>();
                        dic.Add(a, eventDispatchers);
                    }
                    eventDispatchers.Add(new SortEvent(dispatcher.SortIndex, dispatcher.Handle));                   
                }
            }
        }

        public void RemoveDispatcher(iEventDispatcher dispatcher)
        {
            object[] attrs = dispatcher.GetType().GetCustomAttributes(typeof(EventDispatcherAttribute), false);
            foreach (EventDispatcherAttribute e in attrs)
            {
                foreach (var a in e.ids)
                {
                    SortedSet<SortEvent> eventDispatchers;
                    dic.TryGetValue(a, out eventDispatchers);
                    eventDispatchers.RemoveWhere(x => x.action == dispatcher.Handle);
                }
            }
        }
        public void AddAction(EventType eventType, Action<EventType, object[]> action, int SortIndex=0)
        {
            SortedSet<SortEvent> eventDispatchers;
            dic.TryGetValue((int)eventType, out eventDispatchers);
            if (eventDispatchers == null)
            {
                eventDispatchers = new SortedSet<SortEvent>();
                dic.Add((int)eventType, eventDispatchers);
            }
            eventDispatchers.Add(new SortEvent(SortIndex, action));
        }
        public void RemoveAction(Action<EventType, object[]> action)
        {
            dic.Select(x => x.Value).All(x => x.RemoveWhere(y => y.action == action) == 0);
        }
    }
}
