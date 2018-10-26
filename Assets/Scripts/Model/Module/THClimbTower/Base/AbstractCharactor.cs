using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace THClimbTower
{
    /// <summary>
    /// 战斗单位,己方和敌方的基类
    /// </summary>
    public abstract class AbstractCharactor : BaseConfig
    {
        public abstract string Name { get;}

        public int NowHp;
        public int MaxHp;

        public void UseCard(AbstractCard card,AbstractCharactor reciver)
        {
            card.Use(reciver);
        }

        public void ReciveDamage(DamageInfo damage)
        {
            EventSystem.Instance.RunEvent(EventType.BeforeDamageTake);
            if (damage.Damage > 0)
            {
                EventSystem.Instance.RunEvent(EventType.OnDamageTake);
                NowHp -= damage.Damage;
                Log.Debug($"{Name}收到了{damage.Damage}伤害,剩余Hp：{NowHp}");
            }
            if (NowHp <= 0)
            {
                Log.Debug($"{Name}被打死了");
                NowHp = 0;
                //await Game.EventSystem.RunEvent<EventInfo>(EventType.Die);
            }
        }

        public List<AbstractBuff> GetBuffs()
        {
            List<AbstractBuff> output = new List<AbstractBuff>();
            foreach (var buff in GetComponents())
            {
                if (buff is AbstractBuff)
                {
                    output.Add(buff as AbstractBuff);
                }
            }
            return output;
        }

        public T AddBuff<T>()where T : AbstractBuff, new()
        {
            return GetBuff<T>();
        }

        public T GetBuff<T>() where T : AbstractBuff, new()
        {
            T t = this.GetComponent<T>();
            if (t == null)
            {
                t = this.AddComponent<T>();
                if (t is iBaseEventDispather)
                    EventSystem.Instance.AddDispatcher(t as iBaseEventDispather);
            }
            return t;
        }
        public void RemoveBuff<T>() where T : AbstractBuff, new()
        {
            T t = this.GetComponent<T>();
            if (t is iBaseEventDispather)
                EventSystem.Instance.RemoveDispatcher(t as iBaseEventDispather);
            this.RemoveComponent<T>();
        }
    }
}
