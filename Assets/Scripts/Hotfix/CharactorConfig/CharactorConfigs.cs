using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using THClimbTower;

namespace Hotfix.CharactorConfigs
{
    [CharactorConfig(CharactorTypeEnum.Marisa)]
    public class CharactorConfig_Marisa : AbstractCharactorConfig
    {
        public override AbstractCharactorConfig Init()
        {
            MaxHp = 40;
            Name = "雾雨魔理沙";
            Desc = "住在森林中的魔法使，喜欢使用魔炮和星形弹幕。";
            ImageName = "Marisa";
            BaseCardID = new List<int>() {
                Card.CardEnum.TestAttack,
                Card.CardEnum.TestAttack,
                Card.CardEnum.TestAttack,
                Card.CardEnum.TestDefence,
                Card.CardEnum.TestDefence,
            };
            return this;
        }
    }
    [CharactorConfig(CharactorTypeEnum.Alice)]
    public class CharactorConfig_Alice : AbstractCharactorConfig
    {
        public override AbstractCharactorConfig Init()
        {
            MaxHp = 40;
            Name = "爱丽丝玛格特罗伊德";
            Desc = "住在森林中的人偶师。";
            ImageName = "Alice";
            BaseCardID = new List<int>() {
                Card.CardEnum.TestAttack,
                Card.CardEnum.TestAttack,
                Card.CardEnum.TestAttack,
                Card.CardEnum.TestDefence,
                Card.CardEnum.TestDefence,
            };
            return this;
        }
    }
    [CharactorConfig(CharactorTypeEnum.Sakuya)]
    public class CharactorConfig_Sakuya : AbstractCharactorConfig
    {
        public override AbstractCharactorConfig Init()
        {
            MaxHp = 40;
            Name = "十六夜咲夜";
            Desc = "红魔馆的女仆。";
            ImageName = "Sakuya";
            BaseCardID = new List<int>() {
                Card.CardEnum.TestAttack,
                Card.CardEnum.TestAttack,
                Card.CardEnum.TestAttack,
                Card.CardEnum.TestDefence,
                Card.CardEnum.TestDefence,
            };
            return this;
        }
    }
}
