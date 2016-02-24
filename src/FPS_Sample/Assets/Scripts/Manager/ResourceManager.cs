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
        /// ��ʼ��
        /// </summary>
        public void initialize(Action func) {
            if (func != null) func();    //��Դ��ʼ����ɣ��ص���Ϸ��������ִ�к������� 
        }

        /// <summary>
        /// �����ز�
        /// </summary>
        public AssetBundle LoadBundle(string name) {
            string uri = Util.DataPath + name.ToLower() + ".assetbundle";
            if (abLoaded.ContainsKey(uri)) {
                return abLoaded[uri];
            }

            byte[] stream = null;
            AssetBundle bundle = null;
            stream = File.ReadAllBytes(uri);
            bundle = AssetBundle.CreateFromMemoryImmediate(stream); //�������ݵ��زİ�
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
        /// ������Դ
        /// </summary>
        void OnDestroy() {
            if (shared != null) shared.Unload(true);
            Debug.Log("~ResourceManager was destroy!");
        }
    }
}