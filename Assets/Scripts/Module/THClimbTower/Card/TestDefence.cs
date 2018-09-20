using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THClimbTower.Buff;

namespace THClimbTower.Card
{
    [Card(1)]
    public class TestDefence : AbstractPlayerCard
    {
        public override void CardLogic(AbstractCharactor reciver)
        {
            Buff_Armor armor = Owner.GetBuff<Buff_Armor>();
            armor.Amount += 5;
            Model.Log.Debug($"{Owner?.Name} add 5 armor,Now Armor:{armor.Amount}");
            ThrowToCemetery();
        }
        public override AbstractCard Init()
        {
            BaseDesc = "获得$Armor$点护甲";
            BaseArmor = 5;
            Cost = 1;
            Title = "防御";
            Pic = "armaments";
            return this;
        }
    }
}