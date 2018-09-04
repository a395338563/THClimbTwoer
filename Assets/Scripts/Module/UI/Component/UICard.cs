using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyGUI;

namespace Model
{
    public class UICard
    {
        THClimbTower.PlayerCard playerCard;
        GComponent gCard;
        public UICard(GComponent gCard, THClimbTower.PlayerCard card)
        {
            this.gCard = gCard;
            this.playerCard = card;
        }
        public void Fresh()
        {
            gCard.GetChild("CardCost").text = playerCard.Cost.ToString();
            gCard.GetChild("CardDesc").text = playerCard.Desc;
            gCard.GetChild("CardName").text = playerCard.Title;
            gCard.GetChild("CardType").text = playerCard.CardType.ToString();
        }
    }
}
