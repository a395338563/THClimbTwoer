using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public class TestDefence : PlayerCard
    {
        public override Task Use(BattleCharactor user, BattleCharactor reciver)
        {
            Buff_Armor armor = user.GetBuff<Buff_Armor>();
            armor.LastTime += 5;
            Model.Log.Debug($"{user?.Name} add 5 armor,Now Armor:{armor.LastTime}");
            ThrowToCemetery();
            return Task.CompletedTask;
        }

        public override async Task<bool> UseAble(BattleCharactor reciver)
        {
            return true;
        }

        public override async Task<bool> UseAbleInHand()
        {
            return true;
        }
    }
}