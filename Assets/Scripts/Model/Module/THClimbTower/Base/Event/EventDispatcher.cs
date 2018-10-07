using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public interface iBaseEventDispather
    {
        //BaseEvent[] baseEvents { get; }
    }
    public interface iEventDispatcher: iBaseEventDispather
    {
        void Handle(EventType eventType);
    }
    public interface iEventDispatcher<T>: iBaseEventDispather
    {
        void Handle(EventType eventType, T t);
    }
    public interface iEventDispatcher<T,T1> : iBaseEventDispather
    {
        void Handle(EventType eventType, T t,T1 t1);
    }
    public interface iEventDispatcher<T, T1, T2> : iBaseEventDispather
    {
        void Handle(EventType eventType, T t, T1 t1,T2 t2);
    }
}
