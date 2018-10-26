using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Hotfix.View
{
    [GameUIView(UIViewType.TestBattle)]
    public class TestBattleView : GameUIView
    {
        public override string PackageName { get; set; } = "UI";

        public override string ViewName { get; set; } = "BattleUI";

        public override void Create()
        {
            THClimbTower.EventSystem.Instance.RunEvent(THClimbTower.EventType.TestBattle);
        }

        public override void OnEnter()
        {
            
        }
    }
}
