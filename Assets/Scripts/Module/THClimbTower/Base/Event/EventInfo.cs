using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    /// <summary>
    /// 继承此类后可以成为用于事件通信
    /// </summary>
    public class EventInfo : Model.Entity
    {

    }

    public class DamageInfo: EventInfo
    {
        public int Damage;
    }
}
