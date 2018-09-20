using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace THClimbTower
{
    /// <summary>
    /// 所有卡牌的基类
    /// </summary>
    public abstract class AbstractCard
    {
        public int BaseDamage { get; set; }
        public int BaseArmor { get; set; }
        public int BaseHits { get; set; }
        public AbstractCharactor Owner { get; set; }
        public int Damage, Armor, Hits;
        public void Use(AbstractCharactor reciver)
        {
            Game.EventSystem.RunEvent(EventType.BeforeCardUse, this, Owner, reciver);
            CardLogic(reciver);
            Game.EventSystem.RunEvent(EventType.AfterCardUse, this, Owner, reciver);
        }
        public abstract void CardLogic(AbstractCharactor reciver);
        /// <summary>
        /// 在这里做初始化
        /// </summary>
        /// <returns></returns>
        public virtual AbstractCard Init()
        {
            return this;
        }
    }
}
