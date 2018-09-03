using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [GameUIView(UIViewType.Battle)]
    public class BattleView : GameUIView
    {
        public override string PackageName { get; set; } = "UI";

        public override string ViewName { get; set; } = "BattleUI";

        public override void Creat()
        {
            THClimbTower.Game.Instance.StartGame(THClimbTower.CharactorTypeEnum.Reimu, THClimbTower.CharactorTypeEnum.Marisa);
            THClimbTower.Player player = THClimbTower.Game.Instance.player;
            MainView.GetChild("PlayerName").text = player.Name;
            MainView.GetChild("H").text = $"{player.NowHp}/{player.MaxHp}";
            MainView.GetChild("n46").onClick.Add((x) =>
            {
                usePotion(MainView.GetChild("n46").data);
            });
            MainView.GetChild("n46").data = player.potions[0];
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
