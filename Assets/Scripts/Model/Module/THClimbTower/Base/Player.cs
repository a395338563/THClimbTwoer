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
        public AbstractCharactorConfig MainCharactorType, HelpCharactorType;
        /// <summary>
        /// 获取和改变玩家金钱
        /// </summary>
        public int Gold
        {
            get { return gold; }
            set
            {
                Game.Instance.EventSystem.Call(EventType.GoldChange, new ValueChange()
                {
                    BeforeValue = gold,
                    AfterValue = value
                });
                gold = value;
            }
        }
        int gold;
        public int Power { get;private set; }
        public int MaxPower { get; set; }
        public int HelpPower { get; private set; }
        public int MaxHelpPower { get; set; }
        List<AbstractPlayerCard> Deck = new List<AbstractPlayerCard>();
        List<AbstractRelic> Relics = new List<AbstractRelic>();
        //切换人物的时候需要切换遗物，防止遗物因为特殊原因遗失而出错
        List<AbstractRelic> ChangeRelics = new List<AbstractRelic>();
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
        public void Init(AbstractCharactorConfig main,AbstractCharactorConfig help)
        {
            MainCharactorType = main;
            HelpCharactorType = help;
            Deck.Clear();
            Relics.Clear();
            potions.Clear();
            Gold = 0;
            MaxHp = 0;
            //主人物初始能量为2，支援人物初始能量为1
            MaxPower = 2;
            MaxHelpPower = 1;
            InitCharactorConfig(MainCharactorType);
            InitCharactorConfig(HelpCharactorType);
            NowHp = MaxHp;
        }
        void InitCharactorConfig(AbstractCharactorConfig Config)
        {
            //AbstractCharactorConfig Config = CharactorConfigFactory.Instance.Get(charactorTypeEnum);
            foreach (var cardId in Config.BaseCardID)
            {
                Deck.Add(CardFactory.Instance.GetPlayerCard(cardId));
            }
            if (Config == MainCharactorType)
            {
                //foreach (int i in MainCharactorType.BaseRelic)
                    //AddRelics();
            }
            Gold += Config.Gold;
            MaxHp += Config.MaxHp;

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
                Game.Instance.EventSystem.AddDispatcher(relic as iEventDispatcher);
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
                Game.Instance.EventSystem.RemoveDispatcher(relic as iEventDispatcher);
            }
        }
        /// <summary>
        /// 获取遗物
        /// </summary>
        /// <returns></returns>
        public List<AbstractRelic> GetRelics()
        {
            return new List<AbstractRelic>(Relics);
        }
        /// <summary>
        /// 获取卡组
        /// </summary>
        /// <returns></returns>
        public List<AbstractPlayerCard> GetDeck()
        {
            return new List<AbstractPlayerCard>(Deck);
        }
        /// <summary>
        /// 获取卡牌
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(AbstractPlayerCard card)
        {
            Deck.Add(card);
        }
        /// <summary>
        /// 获取卡牌
        /// </summary>
        /// <param name="CardId"></param>
        /// <param name="Number"></param>
        public void AddCard(int CardId,int Number = 1)
        {
            for (int i = 0; i < Number; i++)
                Deck.Add(CardFactory.Instance.GetPlayerCard(CardId));
        }
        /// <summary>
        /// 失去卡牌
        /// </summary>
        /// <param name="card"></param>
        public void RemoveCard(AbstractPlayerCard card)
        {
            if (!Deck.Remove(card))
            {
                throw new Exception($"Can't find {card.Title} at deck");
            }
        }
        /// <summary>
        /// 切换主副角色，todo
        /// </summary>
        public void ChangeCharactor()
        {

        }
        public void ChangePower(int value)
        {
            Power += value;
        }
        public void ChangeHelpPower(int value)
        {
            HelpPower += value;
        }
    }
    public enum CharactorTypeEnum
    {
        Sakuya,
        Marisa,
        Alice,
    }
}
