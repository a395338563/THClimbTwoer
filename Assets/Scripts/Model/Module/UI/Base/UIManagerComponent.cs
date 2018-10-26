using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FairyGUI;

namespace Model
{
    /*[ObjectSystem]
    public class UIManagerComponentEvent : StartSystem<UIManagerComponent>
    {
        public override void Start(UIManagerComponent self)
        {
            self.Awake();
        }
    }*/

    public class UIManagerComponent : Component,IUpdate
    {
        Dictionary<UIViewType, GameUIView> dic = new Dictionary<UIViewType, GameUIView>();
        /// <summary>
        /// 已经add过的包
        /// </summary>
        static List<string> LoadPackage = new List<string>();
        static string PackagePath = "UI/";
        public GameUIView NowSence;

        public void Awake()
        {
            //UIConfig.defaultFont = "SimHei";
            //FontManager.RegisterFont(FontManager.GetFont("font/jianshuhunti"), "迷你简书魂");//初始化字体
            //Add(typeof(Init).Assembly);
            //LoadPackge("BlueSkin");//加载默认皮肤
            //LoadPackge("THCLimbTower");//加载资源
            LoadPackge("UI");//从爬塔偷的资源包
            //LoadSence(UIViewType.Map);//初始化页面
            //Game.Scene.AddComponent<WindowComponent>();
        }

        public GameUIView GetView(UIViewType type)
        {
            return dic[type];
        }

        public void LoadPackge(string PackageName)
        {
            if (LoadPackage.Contains(PackageName))
                return;
            LoadPackage.Add(PackageName);
            UIPackage.AddPackage(PackagePath + PackageName);
        }

        public GameUIView LoadSence(UIViewType type)
        {
            NowSence?.Leave();
            dic[type].Enter();
            dic[type].OnEnter();
            NowSence = dic[type];
            return NowSence;
        }

        public void Add(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            //List<Type> types = Game.Hotfix.GetHotfixTypes();
            foreach (Type type in types)
            {
                object[] attrs = type.GetCustomAttributes(typeof(GameUIViewAttribute), false);

                foreach (object attr in attrs)
                {
                    GameUIViewAttribute aEventAttribute = (GameUIViewAttribute)attr;
                    object obj = Activator.CreateInstance(type);
                    if (!dic.ContainsKey(aEventAttribute.Type))
                    {
                        dic.Add(aEventAttribute.Type, (GameUIView)(obj));
                    }
                    else
                    {
                        Log.Error($"已存在相同的页面:{aEventAttribute.Type}");
                    }
                    //this.allEvents[(EventIdType)aEventAttribute.Type].Add(new IEventMonoMethod(obj));
                }
            }
            //Log.Debug(dic.Count.ToString());
        }

        public void Update()
        {
            if (NowSence is IUpdate)
            {
                (NowSence as IUpdate).Update();
            }
        }
    }
}
