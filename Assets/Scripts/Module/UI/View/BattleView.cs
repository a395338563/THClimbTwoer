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
    public class BattleView : GameUIView
    {
        public override string PackageName { get; set; } = "UI";

        public override string ViewName { get; set; } = "BattleUI";

        THClimbTower.Battle battle;

        GList HandList, RelicList;

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
        }

        void FreshPage()
        {
            //刷新手牌
            HandList.RemoveChildrenToPool();
            foreach (var card in battle.Hand)
            {
                GComponent com = HandList.AddItemFromPool().asCom;
                UICard uICard = new UICard(com, card);
                uICard.Fresh();
            }

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
    }
}
