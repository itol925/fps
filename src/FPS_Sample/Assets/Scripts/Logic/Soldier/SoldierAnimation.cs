using UnityEngine;
using System.Collections;
using SimpleFramework;

public class SoldierAnimation : LuaBehaviour
{
    private enum Clips {
        DefaultTake = 0,
        Crouch_Idle,        // 蹲
        Crouch_Walk,        // 蹲走
        Crouch_Walk_Front_Left,
        Crouch_Walk_Front_Right,
        Crouch_Walk_Left,
        Crouch_Walk_Right,
        Fire_Still,         // 机枪开火
        Idle,               // 端着机枪静止
        Idle_Knife_Nade,    // 刀or手榴弹静止
        Jump_Pose,          // T pose
        KnifeHit,           // 捅刀
        LandFromHeight,     // 高处落地
        MeleeWithWeapon,    // 近身攻击
        Pistol_Idle_Aim,    // 手枪瞄准
        Pistol_Idle_Still,  // 手枪站立
        Pistol_Fire,        // 手枪开枪
        Pistol_Reload,      // 手枪换子弹
        Pistol_TakeIn,      // 掏手枪
        PrimaryTakeIn,      // 
        Prone_Idle,         // 卧倒
        Prone_Idle_Knife_Nade,// 卧倒持刀
        Prone_Idle_Pistol,  // 卧倒持枪
        Prone_KnifeMelee,   // 卧倒捅刀
        Prone_Move_Front,   // 卧倒前进
        Prone_Move_Left,
        Prone_Move_Right,
        Prone_NadeThrow,    // 卧倒投掷
        Prone_Reload_Pistol,// 卧倒换子弹
        Prone_Reload_Primary,
        Reload,             // T-pose
        Run,                // 跑步
        Run_Front_Left,
        Run_Front_Right,
        ThrowNade,          // 投掷
        Walk_Right,
        Walk_Run,           // 端着机枪跑
        Walk_Run_FrontLeft, 
        Walk_Run_FrontRight,
        WalkBack,
        Weapon_Idle,        // T pose
    };
    void Awake() {
        Animation a = gameObject.GetComponent<Animation>();
        
        a.wrapMode = WrapMode.Loop;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
