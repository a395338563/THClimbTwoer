using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public class TestAttack : PlayerCard
    {
        public override async Task Use(Charactor user, Charactor reciver)
        {
            await reciver.ReciveDamage(new DamageInfo() { Damage = Damage });
            ThrowToCemetery();
        }

        public override async Task<bool> UseAble(Charactor reciver)
        {
            return true;
        }

        public override async Task<bool> UseAbleInHand()
        {
            return true;
        }
    }
}
