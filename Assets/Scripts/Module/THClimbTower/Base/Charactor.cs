using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace THClimbTower
{
    public abstract class Charactor : Entity
    {
        public abstract string Name { get;}

        public int NowHp;
        public int MaxHp;

        public async Task UseCard(Card card,Charactor reciver)
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
