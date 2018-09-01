using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public class Player : Charactor
    {
        public CharactorTypeEnum MainCharactorType, HelpCharactorType;
        public int Gold;
        public int Power;
        public int MaxPower;
        public List<PlayerCard> PlayerCards = new List<PlayerCard>();
        public List<Relic> Relics = new List<Relic>();
        public List<Potion> potions = new List<Potion>();

        public override string Name
        {
            get
            {
                return MainCharactorType.ToString();
            }
        }
        /// <summary>
        /// 初始化卡组，金钱等信息
        /// </summary>
        public void Init()
        {
            MaxHp = 100;
            NowHp = 100;
            for (int i = 0; i < 5; i++)
            {
                TestAttack t = new TestAttack()
                {
                    BaseDesc = "造成$Damage$点伤害",
                    BaseDamage = 6,
                };
                PlayerCards.Add(t);
            }
        }
        /// <summary>
        /// 获得遗物
        /// </summary>
        /// <param name="relic"></param>
        public void AddRelics(Relic relic)
        {
            Relics.Add(relic);
            if (relic is iEventWatcher)
            {
                Game.EventSystem.AddWatcher(relic as iEventWatcher);
            }
        }
        /// <summary>
        /// 失去遗物
        /// </summary>
        /// <param name="relic"></param>
        public void RemoveRelics(Relic relic)
        {
            Relics.Remove(relic);
            if (relic is iEventWatcher)
            {
                Game.EventSystem.RemoveWatcher(relic as iEventWatcher);
            }
        }
    }
    public enum CharactorTypeEnum
    {
        Reimu,
        Marisa,
        Alice,
    }
}
