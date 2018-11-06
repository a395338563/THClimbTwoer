using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyGUI;
using THClimbTower;
using Model;

namespace Hotfix.View
{
    [GameUIView(UIViewType.ChooseCharactor)]
    public class ChooseCharactorView:GameUIView
    {
        public override string PackageName => "ChooseCharactor";

        public override string ViewName => "ChooseView";

        AbstractCharactorConfig NowSelectCharactor, MainCharactor, HelpCharactor;
        GComponent NowSelectComponent, MainSelectComponent, HelpSelectComponent;
        GList CharactorList;
        public override void Create()
        {
            CharactorList = MainView.GetChild("CharactorList").asList;
            CharactorList.RemoveChildrenToPool();
            GButton choose = MainView.GetChild("Choose").asButton;
            GButton unChoose = MainView.GetChild("UnChoose").asButton;
            foreach (var a in CharactorConfigFactory.Instance.GetAll())
            {
                GComponent g = CharactorList.AddItemFromPool().asCom;
                g.icon = IconHelper.GetHeadIcon(a.ImageName);
                g.data = a;
                g.onClick.Add(() =>
                {
                    MainView.GetChild("BigImage").asLoader.url = "Hero/" + a.ImageName;
                    NowSelectCharactor = a;
                    NowSelectComponent = g;
                    bool Allselect = MainCharactor != null && HelpCharactor != null;
                    bool Inselect = MainCharactor == a | HelpCharactor == a;
                    choose.enabled = !Allselect && !Inselect;
                    unChoose.enabled = Inselect;

                    MainView.GetChild("Name").text = a.Name;
                    MainView.GetChild("Desc").text = a.Desc;
                });
            }
            choose.onClick.Add(() =>
            {
                if (MainCharactor == null)
                {
                    MainCharactor = NowSelectCharactor;
                    NowSelectComponent.GetController("Choose").selectedIndex = 1;
                }
                else
                {
                    HelpCharactor = NowSelectCharactor;
                    NowSelectComponent.GetController("Choose").selectedIndex = 2;
                    MainView.GetChild("StartGame").visible = true;
                }
                choose.enabled = false;
                unChoose.enabled = true;
            });
            unChoose.onClick.Add(() =>
            {
                if (HelpCharactor != null)
                    HelpCharactor = null;
                else
                    MainCharactor = null;
                NowSelectComponent.GetController("Choose").selectedIndex = 0;
                MainView.GetChild("StartGame").visible = false;
                choose.enabled = true;
                unChoose.enabled = false;
            });
            MainView.GetChild("StartGame").onClick.Add(() =>
            {
                THClimbTower.Game.Instance.StartGame(MainCharactor, HelpCharactor,(int)System.DateTime.Now.Ticks);
                Model.Game.Scene.GetComponent<UIManagerComponent>().LoadSence(UIViewType.Map);
            });
        }

        public override void OnEnter()
        {
            CharactorList.GetChildAt(0).onClick.Call();
        }
    }
}
