using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using SimpleFramework.Manager;
using SimpleFramework;

public class AppFacade
{
    private static AppFacade _instance;

    public AppFacade() : base()
    {
    }

    public static AppFacade Instance
    {
        get{
            if (_instance == null) {
                _instance = new AppFacade();
            }
            return _instance;
        }
    }

    /// <summary>
    /// 启动框架
    /// </summary>
    public void StartUp() { 
        if (!SimpleFramework.Util.CheckEnvironment()) 
            return;

        //-----------------初始化管理器-----------------------
        AddManager(ManagerName.Lua, new LuaScriptMgr());

        AddManager<PanelManager>(ManagerName.Panel);
        AddManager<MusicManager>(ManagerName.Music);
        AddManager<TimerManager>(ManagerName.Timer);
        AddManager<NetworkManager>(ManagerName.Network);
        AddManager<ResourceManager>(ManagerName.Resource);
        AddManager<ThreadManager>(ManagerName.Thread);

        //AddManager<MapManager>(ManagerName.Map);

        AddManager<GameManager>(ManagerName.Game);
        Debug.Log("SimpleFramework StartUp-------->>>>>");
    }

    public void Observe() {
        NotificationCenter.Instance.registerObserve(new AppViewObserver());
        NotificationCenter.Instance.registerObserve(new SocketObserver());
    }

    //SimpleFramework Code By Jarjin lee
    static GameObject m_GameManager;
    static Dictionary<string, object> m_Managers = new Dictionary<string, object>();

    GameObject AppGameManager {
        get {
            if (m_GameManager == null) {
                m_GameManager = GameObject.Find("GameManager");
            }
            return m_GameManager;
        }
    }

    /// <summary>
    /// 添加管理器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public void AddManager(string typeName, object obj) {
        if (!m_Managers.ContainsKey(typeName)) {
            m_Managers.Add(typeName, obj);
        }
    }

    /// <summary>
    /// 添加Unity对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public T AddManager<T>(string typeName) where T : Component {
        object result = null;
        m_Managers.TryGetValue(typeName, out result);
        if (result != null) {
            return (T)result;
        }
        Component c = AppGameManager.AddComponent<T>();
        m_Managers.Add(typeName, c);
        return default(T);
    }

    /// <summary>
    /// 获取系统管理器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public T GetManager<T>(string typeName) where T : class {
        if (!m_Managers.ContainsKey(typeName)) {
            return default(T);
        }
        object manager = null;
        m_Managers.TryGetValue(typeName, out manager);
        return (T)manager;
    }

    /// <summary>
    /// 删除管理器
    /// </summary>
    /// <param name="typeName"></param>
    public void RemoveManager(string typeName) {
        if (!m_Managers.ContainsKey(typeName)) {
            return;
        }
        object manager = null;
        m_Managers.TryGetValue(typeName, out manager);
        Type type = manager.GetType();
        if (type.IsSubclassOf(typeof(MonoBehaviour))) {
            GameObject.Destroy((Component)manager);
        }
        m_Managers.Remove(typeName);
    }
}

