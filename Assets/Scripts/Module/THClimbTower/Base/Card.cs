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
    public abstract class Card
    {
        public int BaseDamage { get; set; }
        public int BaseArmor { get; set; }
        public int BaseHits { get; set; }
        public BattleCharactor Owner { get; set; }
        public int Damage, Armor, Hits;
        public abstract Task Use(BattleCharactor user, BattleCharactor reciver);
        /// <summary>
        /// 在这里做初始化
        /// </summary>
        /// <returns></returns>
        public virtual Card Init()
        {
            return this;
        }
    }
}
