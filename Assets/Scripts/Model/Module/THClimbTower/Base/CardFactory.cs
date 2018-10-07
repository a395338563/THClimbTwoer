using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace THClimbTower
{
    public class CardFactory: BaseFactory<AbstractCard, CardAttribute>
    {
        public static CardFactory Instance
        {
            get
            {
                return instance == null ? instance = new CardFactory() : instance;
            }
        }
        protected static CardFactory instance;
    }
   /* public class CardFactory:Component,IAwake
    {
        public static CardFactory Instance;
        Dictionary<int, Type> CardDic;
        public void Awake()
        {
            Instance = this;
            CardDic = new Dictionary<int, Type>();
            AddCard(Assembly.GetExecutingAssembly());
        }

        public void AddCard(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                Log.Debug(type.ToString());
                object[] attrs = type.GetCustomAttributes(typeof(CardAttribute), false);
                foreach (object attr in attrs)
                {
                    if (! (attr is CardAttribute))
                        continue;
                    CardAttribute cardAttribute = (CardAttribute)attr;
                    if (!CardDic.ContainsKey(cardAttribute.Id))
                    {
                        CardDic.Add(cardAttribute.Id, type);
                    }
                    else
                    {
                        Model.Log.Error($"存在牌有相同ID：{CardDic[cardAttribute.Id].Name},{type.Name}");
                    }
                }
            }
        }

        public AbstractCard Get(int Id)
        {
            return (Activator.CreateInstance(CardDic[Id]) as AbstractCard).Init();
        }
    }*/
    public class CardAttribute : BaseConfigAttribute
    {
        public CardAttribute(int Id):base(Id)
        {
            this.Id = Id;
        }
    }
}
