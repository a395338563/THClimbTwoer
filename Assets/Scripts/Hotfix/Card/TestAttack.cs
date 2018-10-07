using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THClimbTower;

namespace Hotfix.Card
{
    [Card(0)]
    public class TestAttack : AbstractPlayerCard
    {
        public override void CardLogic(AbstractCharactor reciver)
        {
            reciver.ReciveDamage(new DamageInfo() { Damage = Damage });
            ThrowToCemetery();
        }
        public override AbstractCard Init()
        {
            BaseDesc = "造成$Damage$点伤害";
            BaseDamage = 6;
            Cost = 1;
            Title = "打击";
            Pic = "anger";
            return this;
        }
    }
}
