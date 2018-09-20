using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
using THClimbTower.Buff;

namespace THClimbTower
{
    /// <summary>
    /// 战斗单位,己方和敌方的基类
    /// </summary>
    public abstract class AbstractCharactor : Entity
    {
        public abstract string Name { get;}

        public int NowHp;
        public int MaxHp;
        public int Armor
        {
            get
            {
                if (GetBuff<Buff_Armor>() == null)
                    return 0;
                return GetBuff<Buff_Armor>().Amount;
            }
            set
            {
                if (GetBuff<Buff_Armor>() == null)
                    AddComponent<Buff_Armor>();
                GetBuff<Buff_Armor>().Amount = value;
            }
        }

        public async Task UseCard(AbstractCard card,AbstractCharactor reciver)
        {
            card.CardLogic(reciver);
        }

        public async Task ReciveDamage(DamageInfo damage)
        {
            Game.EventSystem.RunEvent(EventType.BeforeDamageTake);
            if (damage.Damage > 0)
            {
                Game.EventSystem.RunEvent(EventType.OnDamageTake);
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
                    //护甲不计入buff列表
                    if (buff is Buff_Armor)
                        continue;
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
                    Game.EventSystem.AddDispatcher(t as iBaseEventDispather);
            }
            return t;
        }
        public void RemoveBuff<T>() where T : AbstractBuff, new()
        {
            T t = this.GetComponent<T>();
            if (t is iBaseEventDispather)
                Game.EventSystem.RemoveDispatcher(t as iBaseEventDispather);
            this.RemoveComponent<T>();
        }
    }
}
