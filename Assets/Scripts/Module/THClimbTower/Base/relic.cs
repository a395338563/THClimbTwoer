using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace THClimbTower
{
    public abstract class Relic : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Icon { get; set; }
        public abstract Task Use();
    }
}
