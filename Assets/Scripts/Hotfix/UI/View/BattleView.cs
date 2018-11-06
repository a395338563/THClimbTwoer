using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyGUI;
using THClimbTower;
using UnityEngine;
using Model;
using Hotfix.UIModule;

namespace Hotfix.View
{
    /*[GameUIView(UIViewType.Battle)]
    public class BattleView : GameUIView, IUpdate
    {
        public override string PackageName { get; set; } = "UI";

        public override string ViewName { get; set; } = "BattleUI";

        THClimbTower.Battle battle;

        GList RelicList;

        GComponent Hand;

        UICharactor player;

        UICurve curve;

        /// <summary>
        /// 为true时，表示玩家选中了一张牌，准备打出
        /// </summary>
        bool InSelectCard = false;

        public override void Create()
        {
            Hand = MainView.GetChild("n60").asCom;
            RelicList = MainView.GetChild("n53").asList;
            curve = new UICurve(MainView.GetChild("n61").asCom);
            //THClimbTower.Game.EventSystem.RunEvent(THClimbTower.EventType.GameStart);

            //THClimbTower.Game.Instance.StartGame(THClimbTower.CharactorTypeEnum.Reimu, THClimbTower.CharactorTypeEnum.Marisa);
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

            MainView.onRightClick.Add(() =>
            {
                InSelectCard = false;
            });

            //右键点击主动使用遗物
            RelicList.onRightClickItem.Add(RelicListClick);

            //HandList.onClickItem.Add((x) =>
            //{
            //    if (x.inputEvent.isDoubleClick)
            //    {
            //        Card c = (x.data as GComponent).data as Card;
            //        player.UseCard(c, player);
            //    }
            //});

            this.player = new UICharactor(MainView.GetChild("n57").asCom, THClimbTower.Game.Instance.player);

            CreateHand();          
        }

        GComponent selectCard;

        List<UICard> HandCards = new List<UICard>();
        void CreateHand()
        {
            Hand.RemoveChildren(0, Hand.numChildren,true);
            //HandList.columnGap = -100;
            for (int i=0;i<battle.Hand.Count;i++)
            {
                AbstractPlayerCard card = battle.Hand[i];
                GComponent com = UIPackage.CreateObject("UI", "CardUI").asCom;//HandList.AddItemFromPool().asCom;
                Hand.AddChild(com);
                UICard uICard = new UICard(com, card, i, battle.Hand.Count - 1);
                HandCards.Add(uICard);
                int k = i;
                com.onRollOver.Set(() => { if (!InSelectCard) foreach (var c in HandCards) c.SetSelectIndex(k); });
                com.onRollOut.Set(() => { if(!InSelectCard) foreach (var c in HandCards) c.SetSelectIndex(-1); });
                com.onClick.Set(() => { foreach (var c in HandCards) c.SetSelectIndex(k, true);InSelectCard = true; });
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
            AbstractRelic relic = g.data as AbstractRelic;
            relic.Use();
        }

        public override void OnEnter()
        {
            //THClimbTower.Game.Instance.StartGame(THClimbTower.CharactorTypeEnum.Reimu, THClimbTower.CharactorTypeEnum.Marisa);
        }

        void usePotion(object o)
        {
            Log.Debug(o.GetType().ToString());
            THClimbTower.AbstractPotion potion = o as THClimbTower.AbstractPotion;
            if (potion == null) return;
            else potion.Use();
        }

        public void Update()
        {
            FreshPage();
            Vector2 v2 = Input.mousePosition;
            v2.y = Screen.height - v2.y;
            Vector2 screenpos = GRoot.inst.GlobalToLocal(v2);

            //Debug.Log(screenpos);

            Vector2 start = new Vector2(960, 780);
            Vector2 contorl = new Vector2(start.x - (screenpos.x - start.x) / 4, screenpos.y + (screenpos.y - start.y) / 2);
            curve.ChangeShape(start, screenpos, contorl);
        }
    }*/
}
