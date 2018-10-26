using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyGUI;
using THClimbTower;
using UnityEngine;
using Model;

namespace Hotfix.View
{
    [GameUIView(UIViewType.Map)]
    public class MapView : GameUIView,IUpdate
    {
        public override string PackageName { get; set; } = "UI";

        public override string ViewName { get; set; } = "Map";

        GComponent GNode;

        public override void Create()
        {
            GNode = MainView.GetChildAt(0).asCom.GetChild("Node").asCom;
            GNode.touchable = true;
        }
        THClimbTower.Map map;
        public override void OnEnter()
        {
            THClimbTower.EventSystem.Instance.RunEvent(THClimbTower.EventType.GameStart);
            //MainView.scale = new Vector2(0.33f, 0.33f);
            map = new THClimbTower.Map();
            map.Creat(0, 10, 5, 6);
            CreatMap(map);
            /*foreach (var t in map.tiles)
            {
                Log.Debug($"{t.X},{t.Y}");
            }*/
        }
        void CreatMap(THClimbTower.Map map)
        {
            GNode.RemoveChildren(0, GNode.numChildren, true);
            foreach (var room in map.tiles)
            {
                GComponent g = UIPackage.CreateObject("UI", "RoomButton").asCom;
                GNode.AddChild(g);
                g.xy = GetTrueXy(room.X, room.Y);
                g.data = room;
                g.onClick.Add(() =>
                {
                    room.OnClick();
                });
                foreach (var r in room.Next)
                {
                    ConnectRoom(GetTrueXy(room.X, room.Y), GetTrueXy(r.X, r.Y));
                }
            }
        }
        Vector2 GetTrueXy(int x, int y)
        {
            return (new Vector2() { x= 440 + x * 200 ,y = 2900 - (730 + y * 155) });
        }

        void ConnectRoom(Vector2 source,Vector2 target)
        {
            Vector2 delta = target - source;
            float angle = Mathf.Atan((-delta.x) / delta.y) * 180 / Mathf.PI;
            float distance = delta.magnitude;
            int num = (int)distance / 16;
            for (int i = 2; i < num - 1; i++)
            {
                GLoader loader = new GLoader();
                loader.width = 16;
                loader.height = 16;
                loader.color = new Color32(80, 80, 80, 255);
                loader.url = "ui://UI/dot1";
                loader.rotation = angle + RandomUtil.Next(-10, 10);
                GNode.AddChild(loader);
                loader.xy = new Vector2(source.x + (target.x - source.x) * i / num, source.y + (target.y - source.y) * i / num);
                loader.xy += new Vector2(RandomUtil.Next(-5, 5), RandomUtil.Next(-5, 5));
            }
        }    

        public void Update()
        {
           
        }
    }
}
