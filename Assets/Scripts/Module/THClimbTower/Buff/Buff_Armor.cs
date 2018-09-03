using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    [EventWatcher(new EventType[] { EventType.BeforeDamageTake, EventType.PlayerTurnStart, EventType.PlayerTurnEnd})]
    public class Buff_Armor : Buff
    {
        public override async Task<object> RunEvent(EventType eventType, object o, params object[] args)
        {
            if (eventType == EventType.BeforeDamageTake)
            {
                //护甲抵挡伤害
                DamageInfo damage = (DamageInfo)o;
                if (LastTime > damage.Damage)
                {
                    Model.Log.Debug($"all {damage.Damage} point Damage have been avoid by armor");
                    LastTime -= damage.Damage;
                    damage.Damage = 0;
                }
                else
                {
                    damage.Damage -= LastTime;
                    LastTime = 0;
                    Model.Log.Debug($"{LastTime} point Damage have been avoid by armor,remain {damage.Damage}Point");
                }
                //int baseDamage = (int)args[0];//第一个参数为伤害原始值
                //ETModel.Log.Debug(damage + "," + baseDamage);
                return damage;
            }
            else if (eventType == EventType.PlayerTurnStart)
            {
                Model.Log.Debug($"{(Parent as BattleCharactor).Name} lose all armor at turn start");
                LastTime = 0;
                return o;
            }
            return o;
        }
    }
}
