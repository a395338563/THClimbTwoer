using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FairyGUI;

namespace Model
{
    [GameUIView(UIViewType.Main)]
    public class MainView : GameUIView
    {
        public override string PackageName { get; set; } = "THClimbTower";

        public override string ViewName { get; set; } = "Main";

        public override void Create()
        {
            MainView.GetChild("n2").onClick.Add(() =>
            {
                Log.Debug("???");
                Game.Scene.GetComponent<UIManagerComponent>().LoadSence(UIViewType.ChooseCharactor);
            });
            MainView.GetChild("n2").onTouchMove.Add((x) =>
            {
                Log.Debug("???");
                Log.Debug(x.inputEvent.mouseWheelDelta.ToString());
            });
        }

        public override void OnEnter()
        {
            
        }
    }
}
