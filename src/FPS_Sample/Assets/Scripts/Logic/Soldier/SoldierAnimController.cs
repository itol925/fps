using UnityEngine;
using System.Collections;
using SimpleFramework;

public class SoldierAnimController : MonoBehaviour
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

    private Animation m_anim;
    private Transform m_trans;
    private string[] m_clips = new string[41];

    void Awake() {
        m_anim = gameObject.GetComponent<Animation>();
        m_trans = transform;
        int i = 0;
        foreach (AnimationState state in m_anim){
            m_clips[i++] = state.name;
        }
    }
    public void updateMoveState(Vector3 velocity) {
        if (velocity == Vector3.zero)
        {
            Idle();
        }
        else {
            Run(velocity);
        }
    }
    void getAngle() {

    }
    void Idle() {
        m_anim.CrossFade("Idle", 0.1f);
    }
    void Run(Vector3 velocity) {
        if (velocity.z > 0)
        {
            m_anim.CrossFade("Walk_Run", 0.1f);
            if (velocity.x > 0.5f)
            {
                m_anim.CrossFade("Walk_Run_FrontRight", 0.1f);
                m_anim["Walk_Run_FrontRight"].wrapMode = WrapMode.Loop;
            }
            else if(velocity.x < -0.5f)
            {
                m_anim.CrossFade("Walk_Run_FrontLeft", 0.1f);
                m_anim["Walk_Run_FrontRight"].wrapMode = WrapMode.Loop;
            }
        }
        else {
            m_anim.CrossFade("WalkBack", 0.1f);
        }
    }

    void Jump(){
        m_anim.CrossFade("", 0.1f);
    }
}
