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
    public abstract class Card : EventInfo
    {
        public int BaseDamage, Damage, BaseArmor, Armor, BaseHits, Hits;
        public abstract Task Use(Charactor user, Charactor reciver);
    }
}
