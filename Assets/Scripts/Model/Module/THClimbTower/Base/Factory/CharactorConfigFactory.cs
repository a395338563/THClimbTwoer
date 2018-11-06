using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace THClimbTower
{
    public class CharactorConfigFactory:BaseFactory<AbstractCharactorConfig, CharactorConfigAttribute>
    {
        public static CharactorConfigFactory Instance
        {
            get
            {
                return instance == null ? instance = new CharactorConfigFactory() : instance;
            }
        }
        protected static CharactorConfigFactory instance;
        //把配置缓存起来，因为不需要重复创建
        Dictionary<int, AbstractCharactorConfig> cache = new Dictionary<int, AbstractCharactorConfig>();
        public override AbstractCharactorConfig Get(int Id)
        {
            AbstractCharactorConfig abstractCharactorConfig;
            if (!cache.TryGetValue(Id,out abstractCharactorConfig))
            {
                abstractCharactorConfig = base.Get(Id).Init();
                cache.Add(Id, abstractCharactorConfig);
            }
            return abstractCharactorConfig;
        }
        public AbstractCharactorConfig Get(CharactorTypeEnum charactorTypeEnum )
        {
            return Get((int)charactorTypeEnum);
        }
        public List<AbstractCharactorConfig> GetAll()
        {
            List<AbstractCharactorConfig> list = new List<AbstractCharactorConfig>();
            foreach (var a in Dic)
                list.Add(Get(a.Key));
            return list;
        }
    }
    public class CharactorConfigAttribute : BaseConfigAttribute
    {
        public CharactorConfigAttribute(CharactorTypeEnum charactorTypeEnum)
        {
            this.Id = (int)charactorTypeEnum;
        }
        public CharactorConfigAttribute(int id)
        {
            this.Id = id;
        }
    }
    public abstract class AbstractCharactorConfig:BaseConfig
    {
        public string Name;
        public string Desc;
        public List<int> BaseCardID;
        public List<int> BaseRelic;
        public int Gold;
        public int MaxHp;
        public string ImageName;
        public abstract AbstractCharactorConfig Init();
    }
}
