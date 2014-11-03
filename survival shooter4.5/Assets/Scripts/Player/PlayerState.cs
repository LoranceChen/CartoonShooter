using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {
    //Idle,Move,Die
    private Animator anim;
	//hurt
	private AudioSource hurtAudio;
    //shooting state
    private LineRenderer gunLine;
    private Light gunLight;
    private ParticleSystem gunParticles;
    private AudioSource gunAudio;
	private CapsuleCollider playerCollider;
    //中间变量，也可定义在相应状态中
    Ray shootRay;
	Rigidbody playerRigidbody;
	Transform gunTransform;
    //状态返回
    public RaycastHit shootHit;
   
    void Awake() {
        anim = GetComponent<Animator>();
        gunLine = GetComponentInChildren<LineRenderer>();
        gunLight = GetComponentInChildren<Light>();
        gunParticles = GetComponentInChildren<ParticleSystem>();
		gunAudio=GameObject.FindGameObjectWithTag("Gun").GetComponent<AudioSource>();
		hurtAudio = GetComponent<AudioSource>();
		playerRigidbody = GetComponent<Rigidbody>();
		gunTransform=GameObject.FindGameObjectWithTag("Gun").transform;
		playerCollider=GetComponent<CapsuleCollider>();
    }
    public void IdleState() 
    {
		anim.SetBool("IsWalking", false);
    }
    public void MoveState(float speed,float h,float v) 
    {
        Vector3 movement = new Vector3(h,0,v);
        movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition(transform.position + movement);
		anim.SetBool("IsWalking", true);
    }
    public void RotationState(int rotateSpeed) 
    {

    }
    public void DieState()
    {
        anim.SetTrigger("Die");
		//玩家的位置不会变了，就死在原地好了
		playerCollider.enabled=false;
		playerRigidbody.useGravity=false;
    }


    //shootingState
    //状态调节参数，射程，伤害
	public RaycastHit ShootingState(float damagePerShot,float range,int shootableMask)
    {
		RaycastHit shootHit;
        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
		gunLine.SetPosition(0, gunTransform.position);

		shootRay.origin = gunTransform.position;
		shootRay.direction = gunTransform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);    
        }
		//反馈信息
		return shootHit;
	}
	//灯光特效状态,shootingState的子状态。完全受shootingState控制
    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }
	//受伤状态
	public void HurtStart()
	{
		hurtAudio.Play();
	}
	
}
