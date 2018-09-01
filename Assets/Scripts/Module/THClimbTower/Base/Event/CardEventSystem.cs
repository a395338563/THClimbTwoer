using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace THClimbTower
{
    public class EventSystem : Component
    {
        Dictionary<EventType, List<SortWatcher>> dic = new Dictionary<EventType, List<SortWatcher>>();
        Dictionary<Type, EventWatcherAttribute> allEvent = new Dictionary<Type, EventWatcherAttribute>();

        bool BreakEvent = false;

        public void BreakNowEvent()
        {
            BreakEvent = true;
        }

        public void AddWatcher(iEventWatcher CardEventWatcher)
        {
            EventWatcherAttribute attr;
            if (allEvent.TryGetValue(CardEventWatcher.GetType(), out attr))
            {
                foreach (var type in attr.Types)
                {
                    add(type, CardEventWatcher, attr.SortIndex);
                }
            }
        }

        private void add(EventType eventType, iEventWatcher CardEventWatcher,int SortIndex)
        {
            List<SortWatcher> list = null;
            dic.TryGetValue(eventType, out list);
            if (list == null)
            {
                list = new List<SortWatcher>();
                dic.Add(eventType, list);
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].SortIndex >= SortIndex)
                {
                    //Log.Debug($"type:{eventType} ,{CardEventWatcherComponent.GetType().Name}插入{i}+{list[i].SortIndex}+{ CardEventWatcherComponent.SortIndex}");
                    list.Insert(i, new SortWatcher(CardEventWatcher, SortIndex));
                    return;
                }
            }
            //Log.Debug($"type:{eventType}没有东西,{CardEventWatcherComponent.GetType().Name}");
            list.Insert(list.Count, new SortWatcher(CardEventWatcher, SortIndex));
        }
        public void RemoveWatcher(iEventWatcher CardEventWatcher)
        {
            EventWatcherAttribute attr;
            if (allEvent.TryGetValue(CardEventWatcher.GetType(), out attr))
            {
                foreach (var type in attr.Types)
                {
                    for (int i = dic[type].Count - 1; i >= 0; i--)
                        if (dic[type][i].watcher == CardEventWatcher)
                            dic[type].Remove(dic[type][i]);
                }
            }
        }

        public async Task<T> RunEvent<T>(EventType eventType, T o = null, params object[] args) where T : EventInfo
        {
            //获取所有对应类型的观察者
            List<SortWatcher> list;
            if (!dic.TryGetValue(eventType, out list))
            {
                Log.Warning($"Cant find eventType:{eventType}");
                return o;
            }
            foreach (SortWatcher CardEventWatcher in list)
            {
                try
                {
                    o = (T)await CardEventWatcher.watcher.RunEvent(eventType, o, args);
                    //如果执行中设置了中断
                    if (BreakEvent)
                    {
                        BreakEvent = false;
                        break;
                    }
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
            return o;
        }
        public void Awake()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in types)
            {
                object[] attrs = type.GetCustomAttributes(typeof(EventWatcherAttribute), false);

                foreach (object attr in attrs)
                {
                    EventWatcherAttribute aEventAttribute = (EventWatcherAttribute)attr;
                    object obj = Activator.CreateInstance(type);
                    iEventWatcher cardEventWatcher = obj as iEventWatcher;
                    if (cardEventWatcher==null)
                    {
                        Log.Error($"{obj.GetType()}未继承cardEventWatcher");
                        continue;
                    }
                    if (!allEvent.ContainsKey(obj.GetType()))
                    {
                        allEvent.Add(obj.GetType(), (aEventAttribute));
                    }
                    else
                    {
                        Log.Error($"已存在相同的类:{cardEventWatcher.GetType()}");
                    }
                    //this.allEvents[(EventIdType)aEventAttribute.Type].Add(new IEventMonoMethod(obj));
                }
            }
        }
        struct SortWatcher
        {
            public iEventWatcher watcher;
            public int SortIndex;

            public SortWatcher(iEventWatcher watcher, int sortIndex)
            {
                this.watcher = watcher;
                SortIndex = sortIndex;
            }
        }
    }
}
