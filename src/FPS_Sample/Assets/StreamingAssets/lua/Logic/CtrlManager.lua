require "Common/define"
-- require "Controller/LoginCtrl"

CtrlManager = {};
local this = CtrlManager;
local ctrlList = {};	--控制器列表--

function CtrlManager.Init()
	warn("CtrlManager.Init----->>>");
	-- ctrlList[CtrlName.Login] = LoginCtrl.New();
	return this;
end

--添加控制器--
function CtrlManager.AddCtrl(ctrlName, ctrlObj)
	ctrlList[ctrlName] = ctrlObj;
end

--获取控制器--
function CtrlManager.GetCtrl(ctrlName)
	return ctrlList[ctrlName];
end

--移除控制器--
function CtrlManager.RemoveCtrl(ctrlName)
	ctrlList[ctrlName] = nil;
end

--关闭控制器--
function CtrlManager.Close()
	warn('CtrlManager.Close---->>>');
end