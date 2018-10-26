using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotfix.Buff;
using THClimbTower;

namespace Hotfix.Card
{
    public class Effect_Defence : AbstractCardEffect
    {
        public override void OnUse(AbstractCharactor user, AbstractCharactor reciver, AbstractCard thisCard)
        {
            Buff_Armor armor = user.GetBuff<Buff_Armor>();
            armor.Amount += 5;
            Model.Log.Debug($"{user?.Name} add 5 armor,Now Armor:{armor.Amount}");
        }
    }
}