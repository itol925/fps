using UnityEngine;
using System.Collections;
using SimpleFramework;

public class Soldier : LuaBehaviour
{
    public SoldierData m_data;
    // Use this for initialization
    void Awake() { }
	void Start () {
        CharacterController ctl = null;
        if (m_data.isMainHero){
            gameObject.AddComponent<FPSInputController>();
            ctl = gameObject.GetComponent<CharacterController>();
        }
        else {
            ctl = gameObject.AddComponent<CharacterController>();
        }
        ctl.height = m_data.height;
        ctl.radius = m_data.radius;
        ctl.center = m_data.center;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
