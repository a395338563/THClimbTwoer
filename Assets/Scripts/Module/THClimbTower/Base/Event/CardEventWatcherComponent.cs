using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace THClimbTower
{
    public interface iEventWatcher
    {
        Task<object> RunEvent(EventType eventType, object o, params object[] args);
    }
}
