using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    [Card(0)]
    public class TestAttack : PlayerCard
    {
        public override async Task Use(BattleCharactor user, BattleCharactor reciver)
        {
            await reciver.ReciveDamage(new DamageInfo() { Damage = Damage });
            ThrowToCemetery();
        }

        public override bool UseAble(BattleCharactor reciver)
        {
            return true;
        }

        public override bool UseAbleInHand()
        {
            return true;
        }
        public override Card Init()
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
