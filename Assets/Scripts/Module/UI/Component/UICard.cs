using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyGUI;
using UnityEngine;

namespace Model
{
    public class UICard
    {
        int index;
        int maxIndex;
        THClimbTower.PlayerCard playerCard;
        GComponent gCard;

        GTweener tweenMoveY, tweenMoveX, tweenRorate;

        public void TweenMoveY(float y,float duration)
        {
            if (duration == 0)
            {
                gCard.y = y;
                tweenMoveY?.Kill(true);
                return;
            }
            tweenMoveY?.Kill(true);
            tweenMoveY = gCard.TweenMoveY(y, duration);
        }

        public void TweenMoveX(float x, float duration)
        {
            if (duration == 0)
            {
                gCard.x = x;
                tweenMoveX?.Kill(true);
                return;
            }
            tweenMoveX?.Kill(true);
            tweenMoveX = gCard.TweenMoveX(x, duration);
        }

        public void TweenRorate(float angle,float duration)
        {
            if (duration == 0)
            {
                gCard.rotation = angle;
                tweenRorate?.Kill(true);
                return;
            }
            tweenRorate?.Kill(true);
            tweenRorate = gCard.TweenRotate(angle, duration);
        }

        /// <summary>
        /// 当前选中的卡片编号，0表示未选中任何卡
        /// </summary>
        /// <param name="SelectIndex"></param>
        public void SetSelectIndex(int SelectIndex)
        {
            if (SelectIndex == this.index)
            {
                Log.Debug($"{index}onSelect");
                //选中自己的情况
                TweenMoveY(-100, 0);
                TweenRorate(0, 0);
                gCard.scale = new Vector2(1, 1);
                return;
            }
            if (SelectIndex == -1)
            {
                Log.Debug($"nothing onSelect");
                //没有卡被选中的情况
                float r = (this.index - maxIndex / 2) * 5;
                //Log.Debug(r.ToString());
                TweenRorate(r, 1f);
                TweenMoveY(Mathf.Abs(300 * (float)(Mathf.Tan((r / 180 * Mathf.PI)))), 1f);
                gCard.scale = new Vector2(0.75f,0.75f);
                return;
            }
            else
            {
                Log.Debug("Other onSelect");
            }
        }

        public UICard(GComponent gCard, THClimbTower.PlayerCard card, int index,int maxIndex)
        {
            this.gCard = gCard;
            this.playerCard = card;
            gCard.data = card;
            this.index = index;
            this.maxIndex = maxIndex;
            SetSelectIndex(-1);
            Fresh();
        }
        public void Fresh()
        {
            gCard.GetChild("CardCost").text = playerCard.Cost.ToString();
            gCard.GetChild("CardDesc").text = playerCard.Desc;
            gCard.GetChild("CardName").text = playerCard.Title;
            gCard.GetChild("CardType").text = playerCard.CardType.ToString();
            gCard.GetChild("CardImage").asLoader.url = $"Card/{playerCard.Pic}";
        }
    }
}
