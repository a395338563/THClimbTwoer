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
    public UIViewType IninScene;
    public UnityEngine.Object dll, mdb;
    private void Awake()
    {
        //暂时先这样加载Hotfix
        byte[] d = (dll as TextAsset).bytes;
        byte[] m = (mdb as TextAsset).bytes;
        Assembly hotfix = Assembly.Load(d, m);

        //读取Hotfix的内容，虽然很奇怪但是就这样吧
        THClimbTower.TileFactory.Instance.Add(hotfix);
        THClimbTower.CardFactory.Instance.Add(hotfix);
        THClimbTower.EnemyFatory.Instance.Add(hotfix);
        THClimbTower.EnemyTeamFactory.Instance.Add(hotfix);
        THClimbTower.EventFactory.Instance.Add(hotfix);

        UIManagerComponent ui= Game.Scene.AddComponent<UIManagerComponent>();
        ui.Add(hotfix);
        ui.Awake();
        ui.LoadSence(IninScene);
    }

    private void Update()
    {
        Game.EventSystem.Update();
    }
}

