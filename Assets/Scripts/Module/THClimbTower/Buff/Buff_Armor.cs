using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    //[EventWatcher(new EventType[] { EventType.BeforeDamageTake, EventType.PlayerTurnStart, EventType.PlayerTurnEnd})]
    [EventDispatcher(EventType.BeforeDamageTake, EventType.PlayerTurnStart, EventType.PlayerTurnEnd)]
    public class Buff_Armor : Buff, iEventDispatcher<DamageInfo>
    {
        //public BaseEvent[] baseEvents { get; } = new BaseEvent[] { EventType.Event_BeforeDamageTake, EventType.Event_PlayerTurnStart, EventType.Event_PlayerTurnEnd };

        public void Handle(EventType baseEvent, DamageInfo damage)
        {
            if (baseEvent == EventType. BeforeDamageTake)
            {
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
            }
            else if (baseEvent == EventType.PlayerTurnStart)
            {
                Model.Log.Debug($"{(Parent as BattleCharactor).Name} lose all armor at turn start");
                LastTime = 0;
            }
        }
    }
}
