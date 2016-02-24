using UnityEngine;
using System.Collections;
using SimpleFramework;

[RequireComponent(typeof(CharacterMotor))]
[RequireComponent(typeof(SoldierAnimController))]
public class Soldier : LuaBehaviour
{
    private SoldierData m_data;
    private CharacterMotor m_motor;
    private CharacterController m_charaCtl;
    private FPSInputController m_inputCtl;

    private SoldierAnimController m_animCtl;

    void Awake() {
        m_motor = GetComponent<CharacterMotor>();
        m_charaCtl = GetComponent<CharacterController>();
        m_animCtl = GetComponent<SoldierAnimController>();
    }
    void Start() {
        if (m_data.isMainHero) {
            m_inputCtl = gameObject.AddComponent<FPSInputController>();
        }
    }
    public void Init(SoldierData data) {
        m_data = data;
        m_charaCtl.height = m_data.height;
        m_charaCtl.radius = m_data.radius;
        m_charaCtl.center = m_data.center;
    }

    public void ExcuteMoveCommand(Vector3 moveDirection, bool jump) {
        m_motor.inputMoveDirection = moveDirection;
        m_motor.inputJump = jump;

        m_animCtl.updateMoveState(m_motor.movement.velocity);
    }
}
