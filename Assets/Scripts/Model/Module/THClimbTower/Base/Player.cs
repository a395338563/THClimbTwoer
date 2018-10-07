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
    public class Player : AbstractCharactor
    {
        public CharactorTypeEnum MainCharactorType, HelpCharactorType;
        public int Gold;
        public int Power;
        public int MaxPower;
        public List<AbstractPlayerCard> Deck = new List<AbstractPlayerCard>();
        public List<AbstractRelic> Relics = new List<AbstractRelic>();
        public List<AbstractPotion> potions = new List<AbstractPotion>();

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
            /*MaxHp = 100;
            NowHp = 100;
            Gold = 2333;
            MainCharactorType = CharactorTypeEnum.Reimu;
            for (int i = 0; i < 5; i++)
            {
                Deck.Add(CardFactory.Instance.Get(0) as AbstractPlayerCard);
                Deck.Add(CardFactory.Instance.Get(1) as AbstractPlayerCard);
                TestAttack t = new TestAttack()
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
                Deck.Add(d);
            }
            potions.Add(new Potion.TestPotion());*/
            //AddRelics(new TestRelic());
        }
        /// <summary>
        /// 获得遗物
        /// </summary>
        /// <param name="relic"></param>
        public void AddRelics(AbstractRelic relic)
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
        public void RemoveRelics(AbstractRelic relic)
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
