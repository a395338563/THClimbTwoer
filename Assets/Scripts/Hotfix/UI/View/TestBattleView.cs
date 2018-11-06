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
        public override string PackageName => "Battle";

        public override string ViewName => "BattleView";

        public override void Create()
        {
            THClimbTower.Game.Instance.EventSystem.Call(THClimbTower.EventType.TestGame);
        }

        public override void OnEnter()
        {
            
        }
    }
}
