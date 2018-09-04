using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    [Card(1)]
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
            BaseDesc = "获得$Armor$点护甲";
            BaseArmor = 5;
            Cost = 1;
            Title = "防御";
            Pic = "armaments";
            return this;
        }
    }
}