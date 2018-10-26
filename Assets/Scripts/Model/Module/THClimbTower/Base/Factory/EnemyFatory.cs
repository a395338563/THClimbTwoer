using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Model;
using THClimbTower;

namespace THClimbTower
{
    public class EnemyFatory : BaseFactory<AbstractEnemy,EnemyAttribute>
    {
        public static EnemyFatory Instance
        {
            get
            {
                return instance == null ? instance = new EnemyFatory() : instance;
            }
        }
        protected static EnemyFatory instance;

        public override AbstractEnemy Get(int Id)
        {
            return base.Get(Id).Init();
        }
    }
    public class EnemyAttribute:BaseConfigAttribute
    {
        public EnemyAttribute(int Id)
        {
            this.Id = Id;
        }
    }
}
