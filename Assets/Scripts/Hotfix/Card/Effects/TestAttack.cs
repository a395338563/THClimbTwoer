using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THClimbTower;

namespace Hotfix.Card
{
    public class Effect_Attack : AbstractCardEffect
    {
        public override void OnUse(AbstractCharactor user, AbstractCharactor reciver, AbstractCard thisCard)
        {
            reciver.ReciveDamage(new DamageInfo() { Damage = thisCard.Damage });
        }
    }
}
