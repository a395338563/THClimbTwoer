using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    /// <summary>
    /// 进入战斗大地图后的玩家信息
    /// </summary>
    public class Player : BattleCharactor
    {
        public CharactorTypeEnum MainCharactorType, HelpCharactorType;
        public int Gold;
        public int Power;
        public int MaxPower;
        public List<PlayerCard> Deck = new List<PlayerCard>();
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
            Gold = 2333;
            MainCharactorType = CharactorTypeEnum.Reimu;
            for (int i = 0; i < 5; i++)
            {
                Deck.Add(CardFactory.Instance.Get(0) as PlayerCard);
                Deck.Add(CardFactory.Instance.Get(1) as PlayerCard);
                /*TestAttack t = new TestAttack()
                {
                    BaseDesc = "造成$Damage$点伤害",
                    BaseDamage = 6,
                    Cost=1,
                    Title="打击",
                    Pic="anger",
                };
                Deck.Add(t);
                TestDefence d = new TestDefence()
                {
                    BaseDesc = "获得$Armor$点护甲",
                    BaseArmor=5,
                    Cost=1,
                    Title="防御",
                    Pic="armaments",
                };
                Deck.Add(d);*/
            }
            potions.Add(new TestPotion());
            //AddRelics(new TestRelic());
        }
        /// <summary>
        /// 获得遗物
        /// </summary>
        /// <param name="relic"></param>
        public void AddRelics(Relic relic)
        {
            Relics.Add(relic);
            if (relic is iEventDispatcher)
            {
                Game.EventSystem.AddDispatcher(relic as iEventDispatcher);
            }
        }
        /// <summary>
        /// 失去遗物
        /// </summary>
        /// <param name="relic"></param>
        public void RemoveRelics(Relic relic)
        {
            Relics.Remove(relic);
            if (relic is iEventDispatcher)
            {
                Game.EventSystem.RemoveDispatcher(relic as iEventDispatcher);
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
