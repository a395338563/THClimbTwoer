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
        public override string PackageName => "Map";

        public override string ViewName => "MapView";

        GComponent GTile, GLine, GBattle;

        public override void Create()
        {
            GTile = MainView.GetChild("Map").asCom.GetChild("Tile").asCom;
            GLine = MainView.GetChild("Map").asCom.GetChild("Line").asCom;
            GBattle = MainView.GetChild("Battle").asCom;

            GTextInput pName = MainView.GetChild("PlayerName").asTextInput;
            pName.text = PlayerPrefs.GetString("PlayerName", "");
            pName.onFocusOut.Add(() => PlayerPrefs.SetString("PlayerName", pName.text));

            MainView.GetChild("Hp").text = $"{THClimbTower.Game.Instance.player.NowHp}/{THClimbTower.Game.Instance.player.MaxHp}";
            MainView.GetChild("Gold").text = THClimbTower.Game.Instance.player.Gold.ToString();

            //监听金币变化
            THClimbTower.Game.Instance.EventSystem.AddAction(THClimbTower.EventType.GoldChange, (t, vs) =>
            {
                ValueChange vc = vs[0] as ValueChange;
                MainView.GetChild("Gold").text = vc.AfterValue.ToString();
            });
            //监听血量变化
            THClimbTower.Game.Instance.EventSystem.AddAction(THClimbTower.EventType.HpChange, (t, vs) =>
            {
                Player p = vs[0] as Player;
                if (p == null) return;
                ValueChange vc = vs[1] as ValueChange;
                MainView.GetChild("Hp").text = $"{vc.AfterValue}/{THClimbTower.Game.Instance.player.MaxHp}";
            });
            //监听战斗开始
            THClimbTower.Game.Instance.EventSystem.AddAction(THClimbTower.EventType.BattleStart, (t, vs) =>
            {
                MainView.GetController("c1").selectedIndex = 1;
                Battle battle = THClimbTower.Game.Instance.NowBattle;
                GComponent gPlayer= UIPackage.CreateObject("Map", "BattleCharactor").asCom;
                GBattle.AddChild(gPlayer);
                new UIModule.UICharactor(gPlayer, THClimbTower.Game.Instance.player);
                foreach (var a in battle.Enemys)
                {
                    GComponent gEnemy = UIPackage.CreateObject("Map", "BattleCharactor").asCom;
                    GBattle.AddChild(gEnemy);
                    UIModule.UICharactor uICharactor = new UIModule.UICharactor(gEnemy,a);
                    gEnemy.xy = new Vector2(a.X, a.Y);
                }
            }, 100);

            THClimbTower.Game.Instance.EventSystem.AddAction(THClimbTower.EventType.FreshMap, FreshMap);
            THClimbTower.Game.Instance.EventSystem.AddAction(THClimbTower.EventType.ReBuildMap, CreatMap);

            //由于Create的时候地图已经生成了，还没有监听上，所以要手动创建一次
            CreatMap(THClimbTower.EventType.ReBuildMap,THClimbTower.Game.Instance.NowMap);
        }

        public override void OnEnter()
        {
            
        }
        Vector2 Getpos(int X,int Y)
        {
            return new Vector2(X * 200, Y * 100 + 300);
        }

        void CreatMap(THClimbTower.EventType type, params object[] Param)
        {
            Map map = Param[0] as Map;
            GTile.RemoveChildren(0, GTile.numChildren, true);
            GLine.RemoveChildren(0, GLine.numChildren, true);
            foreach (Tile tile in map.GetTiles())
            {
                if (tile is StartTile)
                {
                    continue;
                }
                GComponent btn = UIPackage.CreateObject("Map", "MapBtn").asCom;
                GTile.AddChild(btn);
                btn.GetController("c1").selectedIndex = (int)tile.Type;
                btn.data = tile;
                btn.xy = Getpos(tile.X, tile.Y);
                if (btn.x+300 > GTile.width) GTile.width = btn.x+300;
                btn.onClick.Add(async () =>
                {
                    if (!map.CanMove(tile)) return;
                    MainView.touchable = false;
                    await btn.GetTransition("t0").PlayAsync();
                    MainView.touchable = true;
                    map.MoveNext(tile);
                });
                btn.onRightClick.Add(() =>
                {
                    //tile.ShowDeltaInfo();
                });
                if (tile is BossTile) continue;
                foreach (Tile next in tile.GetNexts())
                {
                    //Debug.Log("Connect" + tile.pos() + "," + next.pos());
                    ConnectRoom(Getpos(tile.X, tile.Y), Getpos(next.X, next.Y));
                }
            }
            FreshMap(THClimbTower.EventType.FreshMap, map);
            //FreshCards(game.player.Deck);
        }
        void FreshMap(THClimbTower.EventType type, params object[] Param)
        {
            Map map = Param[0] as Map;
            foreach (GComponent g in GTile.GetChildren())
            {
                Tile t = g.data as Tile;
                if (map.NowTile.tileStatus == Tile.TileStatusEnum.OnTile)
                {
                    g.GetTransition("t1").Stop();
                }
                else
                if (map.CanMove(t))
                {
                    g.GetTransition("t1").Play();
                }
                else
                {
                    g.GetTransition("t1").Play();
                    g.GetTransition("t1").Stop();
                }
            }
        }

        void ConnectRoom(Vector2 source,Vector2 target)
        {
            //System.Random random = new System.Random();
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
                loader.url = "ui://Map/dot1";
                loader.rotation = angle + UnityEngine.Random.Range(-10, 10);
                GLine.AddChild(loader);
                loader.xy = new Vector2(source.x + (target.x - source.x) * i / num, source.y + (target.y - source.y) * i / num);
                loader.xy += new Vector2(UnityEngine.Random.Range(-5, 5), UnityEngine.Random.Range(-5, 5));
            }
        }    

        public void Update()
        {
           
        }
    }
}
