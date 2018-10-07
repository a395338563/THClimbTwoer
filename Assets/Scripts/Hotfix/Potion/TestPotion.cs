using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THClimbTower;

namespace Hotfix.Potion
{
    public class TestPotion : AbstractPotion
    {
        public override void Use()
        {
            Model.Log.Debug("你喝了一瓶药，然而并没有什么卵用");
        }
    }
}
