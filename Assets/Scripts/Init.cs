using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Model;

public class Init : MonoBehaviour
{
    private void Awake()
    {
        Game.Scene.AddComponent<UIManagerComponent>();
    }

    private void Update()
    {
        Game.EventSystem.Update();
    }
}

