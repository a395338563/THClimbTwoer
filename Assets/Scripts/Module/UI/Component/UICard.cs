using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyGUI;
using UnityEngine;
using DG.Tweening;

namespace Model
{
    public class UICard
    {
        int index;
        int maxIndex;
        THClimbTower.AbstractPlayerCard playerCard;
        GComponent gCard;

        Tween tweenY, tweenX, tweenR;

        public void TweenMoveY(float y, float duration)
        {

            Debug.Log(index + ":y+" + y + "last:" + duration);
            if (duration == 0)
            {
                gCard.y = y;
                tweenY?.Kill();
                return;
            }
            tweenY?.Kill();
            tweenY = DOTween.To(() => gCard.y, (x) => gCard.y = x, y, duration);
        }

        public void TweenMoveX(float x, float duration)
        {
            if (duration == 0)
            {
                gCard.x = x;
                tweenX?.Kill();
                return;
            }
            tweenX?.Kill();
            tweenX = DOTween.To(() => gCard.x, (xx) => gCard.x = xx, x, duration);
        }

        public void TweenRorate(float angle, float duration)
        {
            if (duration == 0)
            {
                gCard.rotation = angle;
                tweenR?.Kill();
                return;
            }
            tweenR?.Kill();
            tweenR = DOTween.To(() => gCard.rotation, (xx) => gCard.rotation = xx, angle, duration);
        }

        readonly float[] CardXChange = new[] { 0.5f, 0.35f, 0.25f, 0.1f };

        /// <summary>
        /// 当前选中的卡片编号，0表示未选中任何卡
        /// </summary>
        /// <param name="SelectIndex"></param>
        public void SetSelectIndex(int SelectIndex,bool Click=false)
        {
            TweenMoveX(200 * index, 0.5f);
            if (SelectIndex == this.index)
            {              
                //选中自己的情况
                if (Click)
                {
                    gCard.scale = new Vector2(0.75f, 0.75f);
                    TweenMoveY(-50,0.5f);
                    TweenMoveX(200 * ((float)maxIndex / 2), 0.5f);
                    TweenRorate(0, 0);
                }
                else
                {
                    gCard.scale = new Vector2(1, 1);
                    TweenMoveY(-100, 0);
                    TweenRorate(0, 0);
                }
                return;
            }
            if (SelectIndex == -1)
            {
                //没有卡被选中的情况
                float r = (this.index - (float)maxIndex / 2) * 5;
                gCard.scale = new Vector2(0.75f, 0.75f);
                //Log.Debug(r.ToString());
                TweenRorate(r, 0.5f);
                TweenMoveY(Mathf.Abs(300 * (float)(Mathf.Tan((r / 180 * Mathf.PI)))), 0.5f);
                return;
            }
            else
            {
                int offset = index - SelectIndex;
                float xChange = 0;
                if (Math.Abs(offset) < CardXChange.Length)
                    xChange = CardXChange[Math.Abs(offset)];
                if (offset < 0) xChange *= -1;
                TweenMoveX(200 * (index + xChange), 0.5f);
            }
        }

        public UICard(GComponent gCard, THClimbTower.AbstractPlayerCard card, int index,int maxIndex)
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
            gCard.GetController("UseAble").selectedIndex = playerCard.UseAble ? 0 : 1;
        }
    }
}
