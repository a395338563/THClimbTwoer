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

        public AbstractPlayerCard GetPlayerCard(int id)
        {
            AbstractPlayerCard result = Get(id) as AbstractPlayerCard;
            if (result == null)
                throw new Exception("未配置该类型的playerCardID");
            return result;
        }
        public AbstractEnemyCard GetEnemyCard(int id)
        {
            AbstractEnemyCard result = Get(id) as AbstractEnemyCard;
            if (result == null)
                throw new Exception("未配置该类型的EnemyCardId");
            return result;
        }
    }

    public class CardAttribute : BaseConfigAttribute
    {
        public CardAttribute(int Id)
        {
            this.Id = Id;
        }
    }
}
