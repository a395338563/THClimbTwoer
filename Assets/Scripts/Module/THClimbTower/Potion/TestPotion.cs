using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public class TestPotion : Potion
    {
        public override Task Use()
        {
            Model.Log.Debug("你喝了一瓶药，然而并没有什么卵用");
            return Task.CompletedTask;
        }
    }
}
