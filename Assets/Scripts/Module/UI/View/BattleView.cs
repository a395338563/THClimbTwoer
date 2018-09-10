using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyGUI;
using THClimbTower;

namespace Model
{
    [GameUIView(UIViewType.Battle)]
    public class BattleView : GameUIView,IUpdate
    {
        public override string PackageName { get; set; } = "UI";

        public override string ViewName { get; set; } = "BattleUI";

        THClimbTower.Battle battle;

        GList HandList, RelicList;

        UICharactor player;

        public override void Creat()
        {
            HandList = MainView.GetChild("n52").asList;
            RelicList = MainView.GetChild("n53").asList;

            THClimbTower.Game.Instance.StartGame(THClimbTower.CharactorTypeEnum.Reimu, THClimbTower.CharactorTypeEnum.Marisa);
            battle = THClimbTower.Game.Instance.NowBattle;
            THClimbTower.Player player = THClimbTower.Game.Instance.player;
            MainView.GetChild("PlayerName").text = player.Name;
            MainView.GetChild("H").text = $"{player.NowHp}/{player.MaxHp}";
            MainView.GetChild("n46").onClick.Add((x) =>
            {
                usePotion(MainView.GetChild("n46").data);
            });
            MainView.GetChild("n46").data = player.potions[0];

            MainView.GetChild("EndTurn").onClick.Add(() =>
            {
                battle.EndTurn();
            });

            //右键点击主动使用遗物
            RelicList.onRightClickItem.Add(RelicListClick);

            HandList.onClickItem.Add((x) =>
            {
                if (x.inputEvent.isDoubleClick)
                {
                    Card c = (x.data as GComponent).data as Card;
                    player.UseCard(c, player);
                    FreshHand();
                }
            });           

           this.player= new UICharactor(MainView.GetChild("n57").asCom, THClimbTower.Game.Instance.player);

            FreshHand();
        }

        GComponent selectCard;

        void FreshHand()
        {
            //刷新手牌
            HandList.RemoveChildrenToPool();
            HandList.columnGap = -100;
            for (int i = 0; i < battle.Hand.Count; i++)// card in battle.Hand)
            {
                PlayerCard card = battle.Hand[i];
                GComponent com = HandList.AddItemFromPool().asCom;
                com.onRollOver.Add(async() => { if (selectCard==com) return; selectCard = com;await Task.Delay(100); FreshHand(); });
                com.onRollOut.Add(async () => { selectCard = null; await Task.Delay(100); FreshHand(); });
                if (selectCard!=null&& com == selectCard)
                {
                    com.TweenRotate(0, 0f);
                    com.TweenMoveY(-100, 0);
                    com.scale = new UnityEngine.Vector2(1, 1);
                }
                else
                {
                    float r = (i - battle.Hand.Count / 2) * 5;
                    com.TweenRotate(r, 1f);
                    com.TweenMoveY(Math.Abs(300 * (float)(Math.Tan((double)(r / 180 * Math.PI)))), 1f);
                    com.scale = new UnityEngine.Vector2(0.75f, 0.75f);
                }
                //com.y = Math.Abs(300*(float)(Math.Tan((double)(com.rotation/180*Math.PI))));
                //Log.Debug($"{com.rotation},{com.y}");
                //UICard uICard = new UICard(com, card);
                //uICard.Fresh();
            }
        }

        void FreshPage()
        {
            //FreshHand();
            //刷新遗物
            RelicList.RemoveChildrenToPool();
            foreach (var relic in battle.player.Relics)
            {
                GComponent com = RelicList.AddItemFromPool().asCom;
                com.data = relic;
                com.icon = relic.Icon;
            }

            MainView.GetChild("OpenDeck").asCom.GetChild("n6").text = battle.player.Deck.Count.ToString();
            MainView.GetChild("CardHint").text = battle.Deck.Count.ToString();
            MainView.GetChild("DiscardHint").text = battle.Cemetery.Count.ToString();

            MainView.GetChild("Money").text = battle.player.Gold.ToString();
            MainView.GetChild("WorkName").text = battle.player.Name;
            MainView.GetChild("PlayerName").text = "Tester";

            player.Fresh();
        }

        void RelicListClick(EventContext context)
        {
            GComponent g = context.data as GComponent;
            Relic relic = g.data as Relic;
            relic.Use();
        }

        public override void OnEnter()
        {
            //THClimbTower.Game.Instance.StartGame(THClimbTower.CharactorTypeEnum.Reimu, THClimbTower.CharactorTypeEnum.Marisa);
        }

        void usePotion(object o)
        {
            Log.Debug(o.GetType().ToString());
            THClimbTower.Potion potion = o as THClimbTower.Potion;
            if (potion == null) return;
            else potion.Use();
        }

        public void Update()
        {
            FreshPage();
        }
    }
}
