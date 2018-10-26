using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace THClimbTower
{
    public class EnemyTeamFactory:BaseFactory<EnemyTeamConfig,EnemyTeamAttribute>
    {
        public static EnemyTeamFactory Instance
        {
            get
            {
                return instance == null ? instance = new EnemyTeamFactory() : instance;
            }
        }
        protected static EnemyTeamFactory instance;

        public override EnemyTeamConfig Get(int Id)
        {
            EnemyTeamConfig result = base.Get(Id);
            result.Init();
            return result;
        }
    }

    public class EnemyTeamAttribute:BaseConfigAttribute
    {
        public EnemyTeamAttribute(int Id)
        {
            this.Id = Id;
        }
    }
}
