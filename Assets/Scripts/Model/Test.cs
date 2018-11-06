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
    public UnityEngine.Object dll,mdb;
    private async void Start()
    {
        T();
        //EventListener<EventData>.AddListener((x) => { x.Info += 1; });
        //EventListener<EventData>.AddListener((x) => { Debug.Log(x.Info); });
        //EventListener<EventData>.Handle(new EventData() { Info = 10 });
        /*byte[] d = (dll as TextAsset).bytes;
        byte[] m = (mdb as TextAsset).bytes;
        Assembly assembly = Assembly.Load(d, m);
        //CardFactory.Instance.Awake();


        THClimbTower.CardFactory.Instance.Add(assembly);

        Debug.Log(THClimbTower.CardFactory.Instance.Get(0).GetType().Name);*/
        /*E e = new E();
        e.AddComponent<C>();
        await Task.Delay(1000);
        e.RemoveComponent<C>();*/
        //THClimbTower.Game.Instance.StartGame(THClimbTower.CharactorTypeEnum.Reimu, THClimbTower.CharactorTypeEnum.Marisa);
    }
    void T()
    {
        THClimbTower.Game.Instance.EventSystem.AddAction(THClimbTower.EventType.testEventType, T1, 0);
        THClimbTower.Game.Instance.EventSystem.Call(THClimbTower.EventType.testEventType, 3);
        THClimbTower.Game.Instance.EventSystem.RemoveAction(T1);
        THClimbTower.Game.Instance.EventSystem.Call(THClimbTower.EventType.testEventType, 3);
        //THClimbTower.EventSystem.Instance.AddDispatcher(new TestDispatcher());
        //THClimbTower.EventSystem.Instance.RunEvent(THClimbTower.EventType.testEventType, 1);
    }
    void T1(THClimbTower.EventType type,params object[] vs)
    {
        Debug.Log((int)vs[0]);
    }
}
namespace THClimbTower
{
    [EventDispatcher(EventType.testEventType)]
    public class TestDispatcher : iEventDispatcher
    {
        public int SortIndex => 0;

        public void Handle(EventType eventType, params object[] param)
        {
            Debug.Log((int)param[0]);
        }
    }
}

