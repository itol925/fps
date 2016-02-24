using LuaInterface;
using SimpleFramework;
using System.Collections;
using UnityEngine;

public class InputManager : LuaBehaviour {
    private static InputManager instance;
    public static InputManager getInstance()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find("GameManager");
            instance = go.AddComponent<InputManager>();
        }
        return instance;
        
    }
    private InputManager() { }
    // ---------------------------------------------------

}