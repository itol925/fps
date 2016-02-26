using UnityEngine;
using System.Collections;

/**
 *  @Author : www.xuanyusong.com 
 */
 
[AddComponentMenu("Character/FPS Input Controller")]

public class FPSInputController : MonoBehaviour
{
    private Soldier m_target;
    
    void Start(){
        m_target = GetComponent<Soldier>();
    }

    // Update is called once per frame
    void Update(){
        IssueMoveCommand();
        IssueFireCommand();
    }

    void IssueMoveCommand() {
        // Get the input vector from kayboard or analog stick
        Vector3 directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (directionVector != Vector3.zero){
            // Get the length of the directon vector and then normalize it
            // Dividing by the length is cheaper than normalizing when we already have the length anyway
            var directionLength = directionVector.magnitude;
            directionVector = directionVector / directionLength;

            // Make sure the length is no bigger than 1
            directionLength = Mathf.Min(1, directionLength);

            // Make the input vector more sensitive towards the extremes and less sensitive in the middle
            // This makes it easier to control slow speeds when using analog sticks
            directionLength = directionLength * directionLength;

            // Multiply the normalized direction vector by the modified length
            directionVector = directionVector * directionLength;
        }
        Vector3 di = transform.rotation * directionVector;
        m_target.ExcuteMoveCommand(di, Input.GetButton("Jump"));
    }

    void IssueFireCommand() {
        if(Input.GetButton("Fire1")) {
            m_target.ExceteFireCommand(1);
        }
    }
}