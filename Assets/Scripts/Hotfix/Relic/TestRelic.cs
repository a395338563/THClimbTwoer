using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THClimbTower;

namespace Hotfix.Relic
{
    [EventDispatcher(EventType.BattleStart)]
    public class TestRelic : AbstractRelic, iEventDispatcher
    {
        public override string Icon { get; set; } = "ui://UI/abacus";
        public override string Name { get; set; } = "测试遗物";

        public override void Use()
        {
            Model.Log.Debug("你使用了这个遗物！然而并没有什么卵用");
        }
        public override void Dispose()
        {
            EventSystem.Instance.RemoveDispatcher(this);
            base.Dispose();
        }

        public void Handle(EventType eventType)
        {
            Model.Log.Debug("这遗物没什么卵用，就是提醒你一下战斗开始了");
        }
    }
}
