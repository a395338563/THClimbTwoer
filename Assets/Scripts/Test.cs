using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Model;
using System.Reflection;

public class Test : MonoBehaviour
{
    public UnityEngine.Object dll,mdb;
    private async void Start()
    {
        byte[] d = (dll as TextAsset).bytes;
        byte[] m = (mdb as TextAsset).bytes;
        Assembly assembly = Assembly.Load(d, m);
        THClimbTower.CardFactory.Instance.AddCard(assembly);

        Debug.Log(THClimbTower.CardFactory.Instance.Get(1001).GetType().Name);
        /*E e = new E();
        e.AddComponent<C>();
        await Task.Delay(1000);
        e.RemoveComponent<C>();*/
        //THClimbTower.Game.Instance.StartGame(THClimbTower.CharactorTypeEnum.Reimu, THClimbTower.CharactorTypeEnum.Marisa);
    }

    class E : Entity
    {

    }
    class C : Model.Component, IUpdate
    {
        public void Update()
        {
            Log.Debug("111");
        }
    }
}

