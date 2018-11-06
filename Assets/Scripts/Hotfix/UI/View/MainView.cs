using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FairyGUI;
using Model;

namespace Hotfix.View
{
    [GameUIView(UIViewType.Main)]
    public class MainView : GameUIView
    {
        public override string PackageName => "Main";

        public override string ViewName => "MainView";

        public override void Create()
        {
            MainView.GetChild("StartGame").onClick.Add(()=> {
                Game.Scene.GetComponent<UIManagerComponent>().LoadSence(UIViewType.ChooseCharactor);
            });
        }

        public override void OnEnter()
        {
            
        }
    }
}
