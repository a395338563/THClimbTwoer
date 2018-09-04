using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Model;

public class Test : MonoBehaviour
{
    private async void Start()
    {
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

