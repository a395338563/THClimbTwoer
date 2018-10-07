using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Model;
using System.Reflection;

public class Init : MonoBehaviour
{
    public UnityEngine.Object dll, mdb;
    private void Awake()
    {
        //暂时先这样加载Hotfix
        byte[] d = (dll as TextAsset).bytes;
        byte[] m = (mdb as TextAsset).bytes;
        Assembly hotfix = Assembly.Load(d, m);

        THClimbTower.TileFactory.Instance.Add(hotfix);

        UIManagerComponent ui= Game.Scene.AddComponent<UIManagerComponent>();
        ui.Add(hotfix);
        ui.Awake();
    }

    private void Update()
    {
        Game.EventSystem.Update();
    }
}

