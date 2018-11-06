using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace Model
{
    public class ResourcesComponent : Component, IAwake
    {
        public void Awake()
        {
            
        }
        public void LoadBundle(string assetBundleName)
        {
#if UNITY_EDITOR
            string[] realPath = AssetDatabase.GetAssetPathsFromAssetBundle(assetBundleName);
            foreach (string s in realPath)
            {
                UnityEngine.Debug.Log(s);
                string assetName = Path.GetFileNameWithoutExtension(s);
                UnityEngine.Object resource = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(s);
                //AddResource(assetBundleName, assetName, resource);
            }
#endif
        }
    }
}
