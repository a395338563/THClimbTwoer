using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace THClimbTower
{
    public abstract class AbstractCardEffect:Component
    {
        public abstract void OnUse(AbstractCharactor user, AbstractCharactor reciver,AbstractCard thisCard);
    }
}
