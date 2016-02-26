using UnityEngine;
using System.Collections;
using SimpleFramework;

[RequireComponent(typeof(CharacterMotor))]
[RequireComponent(typeof(SoldierAnimController))]
public class Soldier : LuaBehaviour
{
    private SoldierData m_data;
    private CharacterMotor m_motor;
    //private CharacterController m_charaCtl;
    private FPSInputController m_inputCtl;

    //private SoldierAnimController m_animCtl;

    void Awake() {
        m_motor = GetComponent<CharacterMotor>();
        //m_charaCtl = GetComponent<CharacterController>();
        //m_animCtl = GetComponent<SoldierAnimController>();
    }
    void Start() {
        if (m_data.isMainHero) {
            m_inputCtl = gameObject.AddComponent<FPSInputController>();
            //transform.localScale = new Vector3(0.12f,0.12f,0.12f);
            //SetMainHero();
        }
    }
    public void Init(SoldierData data) {
        m_data = data;
        //m_charaCtl.height = m_data.height;
        //m_charaCtl.radius = m_data.radius;
        //m_charaCtl.center = m_data.center;
    }

    public void ExcuteMoveCommand(Vector3 moveDirection, bool jump) {
        m_motor.inputMoveDirection = moveDirection;
        m_motor.inputJump = jump;
        //m_animCtl.updateMoveState(m_motor.movement.velocity);
        //m_animCtl.updateJumpState(jump);
    }

    public void ExceteFireCommand(int fire) {
        //m_animCtl.UpdateFireState(fire);
    }

    void SetMainHero() {
        AssetBundle bundle = ResManager.LoadBundle("lookobject");
        StartCoroutine(StartCreateLookObject(bundle));
    }

    IEnumerator StartCreateLookObject(AssetBundle bundle){
        GameObject prefab = Util.LoadAsset(bundle, "lookobject");
        yield return new WaitForEndOfFrame();

        if (prefab == null)
        {
            yield break;
        }
        GameObject go = Instantiate(prefab) as GameObject;
        go.name = "lookobject";
        go.transform.parent = transform;
        go.transform.localPosition = new Vector3(0, 0.9f, 0);

        yield return new WaitForEndOfFrame();
    }
}
