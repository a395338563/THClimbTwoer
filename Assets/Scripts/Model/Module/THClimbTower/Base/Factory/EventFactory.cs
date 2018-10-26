using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace THClimbTower
{
    public class EventFactory
    {
        public static EventFactory Instance
        {
            get
            {
                return instance == null ? instance = new EventFactory() : instance;
            }
        }
        protected static EventFactory instance;

        Dictionary<int, iBaseEventDispather> Dic = new Dictionary<int, iBaseEventDispather>();

        public void Add(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                object[] attrs = type.GetCustomAttributes(typeof(BaseEventAttribute), false);
                foreach (object attr in attrs)
                {
                    if (!(attr is BaseEventAttribute))
                        continue;
                    BaseEventAttribute Attribute = (BaseEventAttribute)attr;
                    if (!Dic.ContainsKey(Attribute.Id))
                    {
                        iBaseEventDispather BaseEventDispather= Activator.CreateInstance(type) as iBaseEventDispather;
                        EventSystem.Instance.AddDispatcher(BaseEventDispather);
                        Dic.Add(Attribute.Id, BaseEventDispather);
                        Log.Debug($"添加了规则类{BaseEventDispather.GetType().ToString()}");
                    }
                    else
                    {
                        Model.Log.Error($"存在Config有相同ID：{Dic[Attribute.Id].GetType().ToString()},{type.Name}");
                    }
                    //Game.EventSystem.AddDispatcher(Activator.CreateInstance[]);
                }
            }
        }
        public void RemoveAll()
        {
            foreach (var a in Dic)
                EventSystem.Instance.RemoveDispatcher(a.Value);
            Dic.Clear();
        }
        public iBaseEventDispather Get(int Id)
        {
            return Dic[Id];
        }
    }
    public class BaseEventAttribute : Attribute
    {
        public int Id;
        public BaseEventAttribute(int Id)
        {
            this.Id = Id;
        }
    }
}
