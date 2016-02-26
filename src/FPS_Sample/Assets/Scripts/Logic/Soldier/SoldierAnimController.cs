using UnityEngine;
using System.Collections;
using SimpleFramework;

public class SoldierAnimController : MonoBehaviour
{
    //var poseAnimation : AnimationClip;
	//Idle animations
	public AnimationClip jumpPose;
	public AnimationClip stayIdle;
	public AnimationClip crouchIdle;
	public AnimationClip proneIdle;
	//Walk Animations
	public AnimationClip walkFront;
	public AnimationClip walkBack;
	public AnimationClip walkLeft;
	public AnimationClip walkRight;
	//Run animations
	public AnimationClip runFront;
	//Crouch animations
	public AnimationClip crouchFront;
	public AnimationClip crouchLeft;
	public AnimationClip crouchRight;
	public AnimationClip crouchBack;
	//Prone Animations
	public AnimationClip proneFront;
	public AnimationClip proneLeft;
	public AnimationClip proneRight;
	public AnimationClip proneBack;
	//Weapon animations
	public AnimationClip pistolIdle;
	public AnimationClip knifeIdle;
	public AnimationClip gunIdle;
    
    enum ActionState{ Stand, Crouch, Prone }

    private ActionState m_state;
    private CharacterMotor m_motor;
    private Transform m_trans;
    private Animation m_anim;

    void Awake() {
        m_trans = transform;
        //m_anim = transform.FindChild("ExampleSoldier").gameObject.GetComponent<Animation>();
        m_anim = GetComponent<Animation>();
    }
    void Start() {
        m_motor = gameObject.GetComponent<CharacterMotor>();
        //configureAnimations();
    }
    public void updateMoveState(Vector3 velocity) {
        if (velocity == Vector3.zero)
        {
            m_anim.CrossFade(gunIdle.name, 0.2f);
        }
        else {
            m_anim.CrossFade(runFront.name, 0.2f);
        }
    }
    public void updateJumpState(bool jump) {
        if (jump){
           Jump();
        }
    }

    public void UpdateFireState(int fire) {
        Fire(fire);
    }

    void Idle() {
    }
    void Run(Vector3 velocity) {
    }

    void Jump(){
    }
    void Fire(int fire) {
        
    }

    void configureAnimations(){
	    //Set animations Wrap Mode and Speed
	    if(stayIdle){
		    m_anim[stayIdle.name].wrapMode = WrapMode.Loop;
	    }
	    if(crouchIdle){
		    m_anim[crouchIdle.name].wrapMode = WrapMode.Loop;
	    }
	    if(proneIdle){
		    m_anim[proneIdle.name].wrapMode = WrapMode.Loop;
	    }
	    if(walkFront){
		    m_anim[walkFront.name].wrapMode = WrapMode.Loop;
		    //m_anim[walkFront.name].speed = walkm_animsSpeed;
	    }
	    if(walkBack){
		    m_anim[walkBack.name].wrapMode = WrapMode.Loop;
		    //m_anim[walkBack.name].speed = walkm_animsSpeed;
	    }
	    if(walkLeft){
		    m_anim[walkLeft.name].wrapMode = WrapMode.Loop;
		    //m_anim[walkLeft.name].speed = walkm_animsSpeed;
	    }
	    if(walkRight){
		    m_anim[walkRight.name].wrapMode = WrapMode.Loop;
		    //m_anim[walkRight.name].speed = walkm_animsSpeed;
	    }
	    if(runFront){
		    m_anim[runFront.name].wrapMode = WrapMode.Loop;
		    //m_anim[runFront.name].speed = runm_animsSpeed;
	    }
	    if(crouchFront){
		    m_anim[crouchFront.name].wrapMode = WrapMode.Loop;
		    //m_anim[crouchFront.name].speed = crouchm_animsSpeed;
	    }
	    if(crouchLeft){
		    m_anim[crouchLeft.name].wrapMode = WrapMode.Loop;
		    //m_anim[crouchLeft.name].speed = crouchm_animsSpeed;
	    }
	    if(crouchRight){
		    m_anim[crouchRight.name].wrapMode = WrapMode.Loop;
		    //m_anim[crouchRight.name].speed = crouchm_animsSpeed;
	    }
	    if(crouchBack){
		    m_anim[crouchBack.name].wrapMode = WrapMode.Loop;
		    //m_anim[crouchBack.name].speed = crouchm_animsSpeed;
	    }
	    if(proneFront){
		    m_anim[proneFront.name].wrapMode = WrapMode.Loop;
		    //m_anim[proneFront.name].speed = pronem_animsSpeed;
	    }
	    if(proneLeft){
		    m_anim[proneLeft.name].wrapMode = WrapMode.Loop;
		    //m_anim[proneLeft.name].speed = pronem_animsSpeed;
	    }
	    if(proneRight){
		    m_anim[proneRight.name].wrapMode = WrapMode.Loop;
		    //m_anim[proneRight.name].speed = pronem_animsSpeed;
	    }
	    if(proneBack){
		    m_anim[proneBack.name].wrapMode = WrapMode.Loop;
		    //m_anim[proneBack.name].speed = pronem_animsSpeed;
	    }
    }
}
