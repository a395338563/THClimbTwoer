using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Reflection;

namespace THClimbTower
{
    public class BaseFactory<T, TAttr> : Component where T : BaseConfig where TAttr : BaseConfigAttribute
    {
        //public static BaseFactory Instance;
        Dictionary<int, Type> Dic = new Dictionary<int, Type>();

        public void Add(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                object[] attrs = type.GetCustomAttributes(typeof(TAttr), false);
                foreach (object attr in attrs)
                {
                    if (!(attr is TAttr))
                        continue;
                    TAttr Attribute = (TAttr)attr;
                    if (!Dic.ContainsKey(Attribute.Id))
                    {
                        Dic.Add(Attribute.Id, type);
                    }
                    else
                    {
                        Model.Log.Error($"存在Config有相同ID：{Dic[Attribute.Id].Name},{type.Name}");
                    }
                }
            }
        }

        public void RemoveAll()
        {
            Dic.Clear();
        }
        public T Get(int Id)
        {
            return (Activator.CreateInstance(Dic[Id]) as T);
        }
    }

    public abstract class BaseConfig
    {

    }

    public class BaseConfigAttribute : Attribute
    {
        public int Id;
        public BaseConfigAttribute(int Id)
        {
            this.Id = Id;
        }
    }

    /*public class T : BaseFactory
    {

    }*/
}
