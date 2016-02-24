using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;

namespace SimpleFramework.Manager {
    public class ResourceManager : BehaviourBase {
        private AssetBundle shared;
        Dictionary<string, AssetBundle> abLoaded = new Dictionary<string, AssetBundle>();

        /// <summary>
        /// 初始化
        /// </summary>
        public void initialize(Action func) {
            if (func != null) func();    //资源初始化完成，回调游戏管理器，执行后续操作 
        }

        /// <summary>
        /// 载入素材
        /// </summary>
        public AssetBundle LoadBundle(string name) {
            string uri = Util.DataPath + name.ToLower() + ".assetbundle";
            if (abLoaded.ContainsKey(uri)) {
                return abLoaded[uri];
            }

            byte[] stream = null;
            AssetBundle bundle = null;
            stream = File.ReadAllBytes(uri);
            bundle = AssetBundle.CreateFromMemoryImmediate(stream); //关联数据的素材绑定
            abLoaded.Add(uri, bundle);
            return bundle;
        }
        public void UnLoadBundle(string name, bool unloadAllObject)
        {
            string uri = Util.DataPath + name.ToLower() + ".assetbundle";
            if (!abLoaded.ContainsKey(uri)) {
                return;
            }
            AssetBundle bundle = abLoaded[uri];
            bundle.Unload(unloadAllObject);
            abLoaded.Remove(uri);
        }

        /// <summary>
        /// 销毁资源
        /// </summary>
        void OnDestroy() {
            if (shared != null) shared.Unload(true);
            Debug.Log("~ResourceManager was destroy!");
        }
    }
}