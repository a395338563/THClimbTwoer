using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace THClimbTower
{
    /// <summary>
    /// 战斗单位
    /// </summary>
    public abstract class BattleCharactor : Entity
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
                return GetBuff<Buff_Armor>().LastTime;
            }
            set
            {
                if (GetBuff<Buff_Armor>() == null)
                    AddComponent<Buff_Armor>();
                GetBuff<Buff_Armor>().LastTime = value;
            }
        }

        public async Task UseCard(Card card,BattleCharactor reciver)
        {
            await card.Use(this, reciver);
        }

        public async Task ReciveDamage(DamageInfo Damage)
        {
            DamageInfo damage = await Game.EventSystem.RunEvent(EventType.BeforeDamageTake, Damage);
            if (damage.Damage > 0)
            {
                await Game.EventSystem.RunEvent(EventType.OnDamageTake, damage);
                NowHp -= damage.Damage;
                Log.Debug($"{Name}收到了{damage.Damage}伤害,剩余Hp：{NowHp}");
            }
            if (NowHp <= 0)
            {
                Log.Debug($"{Name}被打死了");
                NowHp = 0;
                await Game.EventSystem.RunEvent<EventInfo>(EventType.Die);
            }
        }

        public List<Buff> GetBuffs()
        {
            List<Buff> output = new List<Buff>();
            foreach (var buff in GetComponents())
            {
                if (buff is Buff)
                {
                    //护甲不计入buff列表
                    if (buff is Buff_Armor)
                        break;
                    output.Add(buff as Buff);
                }
            }
            return output;
        }

        public T AddBuff<T>()where T : Buff, new()
        {
            return GetBuff<T>();
        }

        public T GetBuff<T>() where T : Buff, new()
        {
            T t = this.GetComponent<T>();
            if (t == null)
            {
                t = this.AddComponent<T>();
                Game.EventSystem.AddWatcher(t);
            }
            return t;
        }
        public void RemoveBuff<T>() where T : Buff, new()
        {
            T t = this.GetComponent<T>();
            Game.EventSystem.RemoveWatcher(t);
            this.RemoveComponent<T>();
        }
    }
}
