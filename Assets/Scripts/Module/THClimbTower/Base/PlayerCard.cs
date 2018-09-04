using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public abstract class PlayerCard : Card
    {
        public string Title;
        public string Desc;
        public string Pic;
        public int Cost;
        public CardTypeEnum CardType;

        public string BaseDesc;

        /// <summary>
        /// 当此牌在手中时，能否被打出
        /// 通常诅咒或状态牌返回false
        /// </summary>
        /// <returns></returns>
        public abstract Task<bool> UseAbleInHand();
        /// <summary>
        /// 当此牌选择目标或不选择目标时，能否被打出
        /// </summary>
        /// <param name="reciver">接受者可以为空</param>
        /// <returns></returns>
        public abstract Task<bool> UseAble(BattleCharactor reciver);

        protected void ThrowToCemetery()
        {
            Game.Instance.NowBattle.Hand.Remove(this);
            Game.Instance.NowBattle.Cemetery.Add(this);
        }
        public string GetFinalDesc()
        {
            return Desc;
        }
        public enum CardTypeEnum
        {
            Attack,
            Skill,
            Ablity,
        }
    }
}
