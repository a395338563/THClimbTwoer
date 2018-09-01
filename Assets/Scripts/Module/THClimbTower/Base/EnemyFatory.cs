using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Model;
using THClimbTower;

namespace Model
{
    /*[ObjectSystem]
    public class EnemyFatoryEvent : AwakeSystem<THClimbTower.EnemyFatory>
    {
        public override void Awake(EnemyFatory self)
        {
            self.Awake();
        }
    }*/
}

namespace THClimbTower
{
    public class EnemyFatory : Model.Component,IAwake
    {
        Dictionary<int, Type> dic = new Dictionary<int, Type>();
        public Enemy Get(int ID)
        {
            Type t;
            dic.TryGetValue(ID, out t);
            Enemy e = Activator.CreateInstance(t) as Enemy;
            e.EnenmyInit();
            return e;
        }
        public Enemy Get(EnemyEnum enemyEnum)
        {
            return Get((int)enemyEnum);
        }
        public void Awake()
        { 
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in types)
            {
                object[] attrs = type.GetCustomAttributes(typeof(EnemyAttribute), false);

                foreach (object attr in attrs)
                {
                    EnemyAttribute enemyAttribute = (EnemyAttribute)attr;
                    object obj = Activator.CreateInstance(type);
                    Enemy enemy = obj as Enemy;
                    if (enemy == null)
                    {
                        Log.Error($"{obj.GetType()}未继承Enemy");
                        continue;
                    }
                    if (!dic.ContainsKey(enemyAttribute.ID))
                    {
                        dic.Add(enemyAttribute.ID, type);
                    }
                    else
                    {
                        Log.Error($"{dic[enemyAttribute.ID].GetType()}与{enemy.GetType()}有相同的ID");
                    }
                }
            }
        }
    }
    public class EnemyAttribute:Attribute
    {
        public int ID;
        public EnemyAttribute(int ID)
        {
            this.ID = ID;
        }
        public EnemyAttribute(EnemyEnum enemyEnum)
        {
            this.ID = (int)enemyEnum;
        }
    }
    public enum EnemyEnum
    {
        Maoyu,
    }
}
