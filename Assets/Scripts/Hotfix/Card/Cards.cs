using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THClimbTower;

namespace Hotfix.Card
{
    public partial class CardEnum
    {
        public const int TestAttack = 0;
        public const int TestDefence = 1;
    }

    public partial class CardEnum
    {
        public const int MaoyuHit = 1001;
    }

    [Card(CardEnum.TestAttack)]
    public class TestAttack:AbstractPlayerCard
    {
        public override AbstractCard Init()
        {
            BaseDesc = "造成$Damage$点伤害";
            BaseDamage = 6;
            Cost = 1;
            Title = "打击";
            Pic = "anger";
            AddComponent<Effect_Attack>();
            return this;
        }
    }
    [Card(CardEnum.TestDefence)]
    public class TestDefence : AbstractPlayerCard
    {
        public override AbstractCard Init()
        {
            BaseDesc = "获得$Armor$点护甲";
            BaseArmor = 5;
            Cost = 1;
            Title = "防御";
            Pic = "armaments";
            AddComponent<Effect_Defence>();
            return this;
        }
    }
}
