using LuaInterface;
using SimpleFramework;
using System.Collections;
using UnityEngine;

public class MapManager : LuaBehaviour {
    private static MapManager instance;
    public static MapManager getInstance()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find("GameManager");
            instance = go.AddComponent<MapManager>();
        }
        return instance;
    }
    private MapManager() { }

    private Transform parent;
    //private List<FPSCharaController> soldiers = new List<FPSCharaController>();

    Transform Parent
    {
        get
        {
            if (parent == null)
            {
                GameObject go = GameObject.Find("GameManager");
                if (go != null)
                {
                    parent = go.transform;
                }
            }
            return parent;
        }
    }
   
    public void Load() {
        LoadMap();

        SoldierManager.getInstance().LoadSoldiers();
    }

    public void LoadMap(LuaFunction func = null)
    {
        string name = "bunkerlevel";
        AssetBundle bundle = ResManager.LoadBundle(name);
        StartCoroutine(StartCreateObject(name, bundle, func));
    }

    IEnumerator StartCreateObject(string name, AssetBundle bundle, LuaFunction func = null)
    {
        GameObject prefab = Util.LoadAsset(bundle, name);
        yield return new WaitForEndOfFrame();
        if (Parent.FindChild(name) != null || prefab == null)
        {
            yield break;
        }
        GameObject go = Instantiate(prefab) as GameObject;
        go.name = name;
        go.transform.parent = Parent;

        yield return new WaitForEndOfFrame();

        if (func != null)
            func.Call(go);

    }
}