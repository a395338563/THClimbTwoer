using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace THClimbTower
{
    public abstract class Vfx : Entity
    {
        public abstract Task Play();
    }
}
