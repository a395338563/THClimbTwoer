using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower.Buff
{
    //[EventWatcher(new EventType[] { EventType.BeforeDamageTake, EventType.PlayerTurnStart, EventType.PlayerTurnEnd})]
    [EventDispatcher(EventType.BeforeDamageTake, EventType.PlayerTurnStart, EventType.PlayerTurnEnd)]
    public class Buff_Armor : AbstractBuff, iEventDispatcher<DamageInfo>
    {
        public override string Icon { get; } = "Armor";

        //public BaseEvent[] baseEvents { get; } = new BaseEvent[] { EventType.Event_BeforeDamageTake, EventType.Event_PlayerTurnStart, EventType.Event_PlayerTurnEnd };

        public void Handle(EventType baseEvent, DamageInfo damage)
        {
            if (baseEvent == EventType. BeforeDamageTake)
            {
                if (Amount > damage.Damage)
                {
                    Model.Log.Debug($"all {damage.Damage} point Damage have been avoid by armor");
                    Amount -= damage.Damage;
                    damage.Damage = 0;
                }
                else
                {
                    damage.Damage -= Amount;
                    Amount = 0;
                    Model.Log.Debug($"{Amount} point Damage have been avoid by armor,remain {damage.Damage}Point");
                }
            }
            else if (baseEvent == EventType.PlayerTurnStart)
            {
                Model.Log.Debug($"{(Parent as AbstractCharactor).Name} lose all armor at turn start");
                Amount = 0;
            }
        }
    }
}
