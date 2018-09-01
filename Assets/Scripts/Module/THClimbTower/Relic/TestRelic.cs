using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    [EventWatcher(new EventType[] { EventType.BattleStart})]
    public class TestRelic : Relic,iEventWatcher
    {
        public async Task<object> RunEvent(EventType eventType, object o, params object[] args)
        {
            Model.Log.Debug("这遗物没什么卵用，就是提醒你一下战斗开始了");
            return o;
        }

        public override Task Use()
        {
            Model.Log.Debug("你使用了这个遗物！然而并没有什么卵用");
            return Task.CompletedTask;
        }
        public override void Dispose()
        {
            Game.EventSystem.RemoveWatcher(this);
            base.Dispose();
        }
    }
}
