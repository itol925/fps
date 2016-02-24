using LuaInterface;
using SimpleFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierManager : LuaBehaviour {
    private static SoldierManager instance;
    public static SoldierManager getInstance() {
        if (instance == null) {
            GameObject go = GameObject.Find("GameManager");
            instance = go.AddComponent<SoldierManager>();
        }
        return instance;
    }
    private SoldierManager() { }

    //-----------------------------------
    private Transform parent;
    private List<Soldier> soldiers = new List<Soldier>();
    
    Transform Parent{
        get{
            if (parent == null){
                GameObject go = GameObject.Find("GameManager");
                if (go != null) {
                    parent = go.transform;
                }
            }
            return parent;
        }
    }
    
    public void CreateSoldier(SoldierData data, LuaFunction func = null){
        string name = data.prefab;
        AssetBundle bundle = ResManager.LoadBundle(name);
        StartCoroutine(StartCreateObject(data, bundle, func));
        Debug.LogWarning("CreateObject::>> " + name + " " + bundle);
    }

    IEnumerator StartCreateObject(SoldierData data, AssetBundle bundle, LuaFunction func = null){
        string name = data.prefab;
        GameObject prefab = Util.LoadAsset(bundle, name);
        yield return new WaitForEndOfFrame();

        if (prefab == null){
            yield break;
        }
        GameObject go = Instantiate(prefab) as GameObject;
        go.name = name;
        go.transform.parent = Parent;
        go.transform.localPosition = data.initPos;
      
        Soldier soldier = go.AddComponent<Soldier>();
        soldier.m_data = data;
        soldiers.Add(soldier);

        yield return new WaitForEndOfFrame();

        if (func != null)
            func.Call(go);
        Debug.Log("StartCreatePanel------>>>>" + name);
    }

    public void LoadSoldiers() {
        List<SoldierData> list = getSoldiers();
        for (int i = 0; i < list.Count; i++){
            CreateSoldier(list[i]);
        }
    }
    private List<SoldierData> getSoldiers(){
        List<SoldierData> list = new List<SoldierData>();

        SoldierData soldier1 = new SoldierData();
        soldier1.isMainHero = true;
        list.Add(soldier1);
        
        SoldierData soldier2 = new SoldierData();
        soldier2.initPos = new Vector3(50, 0, 0);
        list.Add(soldier2);

        return list;
    }
}