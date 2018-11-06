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
            Game.Instance.EventSystem.Call(EventType.BeforeDamageTake, damage);
            if (damage.Damage > 0)
            {
                Game.Instance.EventSystem.Call(EventType.OnDamageTake, damage);
                Log.Debug($"{Name}收到了{damage.Damage}伤害,剩余Hp：{NowHp}");
                Game.Instance.EventSystem.Call(EventType.HpChange,this, new ValueChange()
                {
                    AfterValue = NowHp - damage.Damage,
                    BeforeValue = NowHp,
                    Reason = damage
                });
                NowHp -= damage.Damage;
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
                if (t is iEventDispatcher)
                    Game.Instance.EventSystem.AddDispatcher(t as iEventDispatcher);
            }
            return t;
        }
        public void RemoveBuff<T>() where T : AbstractBuff, new()
        {
            T t = this.GetComponent<T>();
            if (t is iEventDispatcher)
                Game.Instance.EventSystem.RemoveDispatcher(t as iEventDispatcher);
            this.RemoveComponent<T>();
        }
    }
}
