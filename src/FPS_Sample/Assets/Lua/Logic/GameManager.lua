require "3rd/pblua/login_pb"
require "3rd/pbc/protobuf"
require "Common/functions"


require "Logic/LuaClass"
require "Logic/CtrlManager"

--管理器--
GameManager = {};
local this = GameManager;

local game; 
local transform;
local gameObject;

-- 要加载到内存中的panel
function GameManager.LuaScriptPanel()
	return '';
end

function GameManager.Awake()
    --warn('Awake--->>>');
end

--启动事件--
function GameManager.Start()
	--warn('Start--->>>');
end

--初始化完成，发送链接服务器信息--
function GameManager.OnInitOK()
    --createPanel("Prompt");
    -- CtrlManager.Init();
    -- local ctrl = CtrlManager.GetCtrl(CtrlName.Login);
    -- if ctrl ~= nil then
    --     ctrl:Awake();
    -- end
    warn('SimpleFramework InitOK--->>>');
    MapManager.getInstance():Load(); 
end

--销毁--
function GameManager.OnDestroy()
	--warn('OnDestroy--->>>');
end
