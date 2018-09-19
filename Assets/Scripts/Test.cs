using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Model;
using System.Reflection;
using THClimbTower;

public class Test : MonoBehaviour
{
    //public UnityEngine.Object dll,mdb;
    private async void Start()
    {
        T();
        //EventListener<EventData>.AddListener((x) => { x.Info += 1; });
        //EventListener<EventData>.AddListener((x) => { Debug.Log(x.Info); });
        //EventListener<EventData>.Handle(new EventData() { Info = 10 });
        /*byte[] d = (dll as TextAsset).bytes;
        byte[] m = (mdb as TextAsset).bytes;
        Assembly assembly = Assembly.Load(d, m);
        THClimbTower.CardFactory.Instance.AddCard(assembly);

        Debug.Log(THClimbTower.CardFactory.Instance.Get(1001).GetType().Name);*/
        /*E e = new E();
        e.AddComponent<C>();
        await Task.Delay(1000);
        e.RemoveComponent<C>();*/
        //THClimbTower.Game.Instance.StartGame(THClimbTower.CharactorTypeEnum.Reimu, THClimbTower.CharactorTypeEnum.Marisa);
    }
    void T()
    {
        THClimbTower.EventSystem.Instance.AddDispatcher(new TestDispatcher());
        THClimbTower.EventSystem.Instance.RunEvent<int>(THClimbTower.EventType.testEventType, 1);
    }
}
namespace THClimbTower
{
    [EventDispatcher(EventType.testEventType)]
    public class TestDispatcher : iEventDispatcher<int>
    {
        public void Handle(EventType baseEvent,int i)
        {
            //if (baseEvent is TestEventType)
            {
                //(baseEvent as TestEventType).GetParams(out i);
                Debug.Log(i);
            }
        }
    }
}

