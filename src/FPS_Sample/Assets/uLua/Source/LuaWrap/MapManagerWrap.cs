using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class MapManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("getInstance", getInstance),
			new LuaMethod("Load", Load),
			new LuaMethod("LoadMap", LoadMap),
			new LuaMethod("New", _CreateMapManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "MapManager", typeof(MapManager), regs, fields, typeof(SimpleFramework.LuaBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMapManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "MapManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(MapManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getInstance(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		MapManager o = MapManager.getInstance();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Load(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		MapManager obj = (MapManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MapManager");
		obj.Load();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadMap(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MapManager obj = (MapManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MapManager");
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 2);
		obj.LoadMap(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetLuaObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetLuaObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

