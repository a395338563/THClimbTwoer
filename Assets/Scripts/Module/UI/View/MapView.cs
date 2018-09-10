using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyGUI;
using THClimbTower;
using UnityEngine;

namespace Model
{
    [GameUIView(UIViewType.Map)]
    public class MapView : GameUIView,IUpdate
    {
        public override string PackageName { get; set; } = "UI";

        public override string ViewName { get; set; } = "Map";

        GComponent GNode;

        public override void Creat()
        {
            GNode = MainView.GetChildAt(0).asCom.GetChild("Node").asCom;
        }
        THClimbTower.Map map;
        public override void OnEnter()
        {
            MainView.scale = new Vector2(0.33f, 0.33f);
             map = new THClimbTower.Map();
            map.CreatAsync(0, 10, 5, 6, 300);
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
                string s = "";
                foreach (var r in room.Next)
                {
                    s += $"r:{r.X},{r.Y}";
                    ConnectRoom(GetTrueXy(room.X, room.Y), GetTrueXy(r.X, r.Y));
                }
            }
        }
        Vector2 GetTrueXy(int x, int y)
        {
            return (new Vector2() { x= 440 + x * 200 ,y = 2900 - (730 + y * 155) });
        }
        public int LeftX = -45;
        public int LeftY = -35;
        public int RightX = 20;
        public int RightY = -50;
        public int CenterX = -10;
        public int CenterY = -50;
        float Distance = 30.5f;
        public void ConnectRoom(Vector2 source,Vector2 target)
        {
            List<GLoader> loader = new List<GLoader>();
            //UnityBehaviour.AddUpdate(() =>   //调试用
            //{
            int dotX = 16, dotY = 16;
            //Vector2 source = new Vector2(sourceRoom.X, sourceRoom.Y);
            //Vector2 target = new Vector2(targetRoom.X, targetRoom.Y);
            var rotation = 0;
            float baseX = 0, baseY = -dotY / 2f;
            Vector2 curPos = new Vector2(source.x, source.y + 20);
            if (source.x > target.x)
            {
                baseX = -10;
                curPos.x += LeftX;
                curPos.y += LeftY;
                rotation = -45;
            }
            else if (source.x < target.x)
            {
                baseX = 10;
                curPos.x += RightX;
                curPos.y += RightY;
                rotation = 45;
            }
            else
            {
                curPos.x += CenterX;
                curPos.y += CenterY;
                baseY = -dotY;
            }

            curPos.x += baseX;
            curPos.y += baseY;

            int i = 0;
            for (int j = 0; j < loader.Count; j++)
            {
                loader[j].visible = false;
            }
            while (i++ < 20)//最多20个格子
            {
                GLoader image;
                if (i >= loader.Count)
                {
                    image = new GLoader();
                    loader.Add(image);
                }
                else
                {
                    image = loader[i];
                    image.visible = true;
                }

                image.width = dotX;
                image.height = dotY;
                image.color = new Color32(80, 80, 80, 255);
                image.url = "ui://UI/dot1";
                GNode.AddChild(image);
                //稍微抖动一下
                image.x = curPos.x + RandomUtil.Next(-5, 5);
                image.y = curPos.y + RandomUtil.Next(-5, 5);
                image.rotation = rotation + RandomUtil.Next(-10, 10);
                curPos.x += baseX;
                curPos.y += baseY;
                var distance = Vector2.Distance(curPos, target);
                if (distance <= Distance)
                    break;
            }
            //sourceRoom.Connect(targetRoom);
            //   return 0;
            //});
        }

        public void Update()
        {
            CreatMap(map);
        }
    }
}
