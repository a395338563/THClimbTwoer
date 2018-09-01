using FairyGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class GameUIView
    {
        public GComponent MainView;
        public abstract string PackageName { get; set; }
        public abstract string ViewName { get; set; }
        public virtual void Enter()
        {
            if (MainView == null)
            {
                Game.Scene.GetComponent<UIManagerComponent>().LoadPackge(PackageName);
                MainView = UIPackage.CreateObject(PackageName, ViewName).asCom;
                MainView.SetSize(GRoot.inst.width, GRoot.inst.height);
                MainView.AddRelation(GRoot.inst, RelationType.Size);
                MainView.fairyBatching = true;
                GRoot.inst.AddChild(MainView);
                Creat();
            }
            else
            {
                MainView.visible = true;
            }
            //OnEnter();
        }

        public abstract void Creat();
        public abstract void OnEnter();

        public virtual void Leave()
        {
            MainView.visible = false;
        }
    }

}
