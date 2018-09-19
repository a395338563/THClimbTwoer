﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public class EventSystem
    {
        public static EventSystem Instance
        {
            get
            {
                return instance == null ? instance = new EventSystem() : instance;
            }
        }
        private static EventSystem instance;
        Dictionary<int, List<iBaseEventDispather>> dic = new Dictionary<int, List<iBaseEventDispather>>();
        public void RunEvent(EventType eventType)
        {
            if (dic.ContainsKey((int)eventType))
                foreach (var a in dic[(int)eventType])
                {
                    (a as iEventDispatcher)?.Handle(eventType);
                }
        }
        public void RunEvent<T>(EventType eventType, T t)
        {
            if (dic.ContainsKey((int)eventType))
                foreach (var a in dic[(int)eventType])
                {
                    (a as iEventDispatcher<T>)?.Handle(eventType, t);
                }
        }
        public void RunEvent<T,T1>(EventType eventType, T t,T1 t1)
        {
            if (dic.ContainsKey((int)eventType))
                foreach (var a in dic[(int)eventType])
                {
                    (a as iEventDispatcher<T, T1>)?.Handle(eventType, t, t1);
                }
        }
        public void RunEvent<T, T1,T2>(EventType eventType, T t, T1 t1,T2 t2)
        {
            if (dic.ContainsKey((int)eventType))
                foreach (var a in dic[(int)eventType])
                {
                    (a as iEventDispatcher<T, T1, T2>)?.Handle(eventType, t, t1, t2);
                }
        }

        public void AddDispatcher(iBaseEventDispather dispatcher)
        {
            object[] attrs= dispatcher.GetType().GetCustomAttributes(typeof(EventDispatcherAttribute), false);
            foreach (EventDispatcherAttribute e in attrs)
            {
                foreach (var a in e.ids)
                {
                    List<iBaseEventDispather> eventDispatchers;
                    dic.TryGetValue(a, out eventDispatchers);
                    if (eventDispatchers == null)
                    {
                        eventDispatchers = new List<iBaseEventDispather>();
                        dic.Add(a, eventDispatchers);
                    }
                    eventDispatchers.Add(dispatcher);
                }
                //dic[e].Add(dispatcher);
            }
        }
        public void RemoveDispatcher(iBaseEventDispather dispatcher)
        {

        }
    }
}