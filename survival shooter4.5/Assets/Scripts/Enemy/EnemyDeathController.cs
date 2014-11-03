using UnityEngine;
using System.Collections;

public class EnemyDeathController : MonoBehaviour {
	Animator anim;
	EnemyCommunicate enemyCommunicate;
	EnemyDirectCommunicate enemyDirectCommunicate;
	NavMeshAgent nav;
	CapsuleCollider capsuleCollider;
	AudioClip deathClip;
	AudioSource deathAudio;
	//中间变量
	bool isSinking;
	bool isDeathed=false;//有没有死过一次，重点在一次
	// Use this for initialization
	void Awake () {
		anim=GetComponent<Animator>();
		enemyCommunicate=GetComponent<EnemyCommunicate>();
		nav=GetComponent<NavMeshAgent>();
		capsuleCollider=GetComponent<CapsuleCollider>();
		deathAudio =GetComponent<AudioSource>();
		deathClip=enemyCommunicate.deathClip;
	}
	void Start()
	{
		//Direct
		enemyDirectCommunicate=GetComponent<EnemyDirectCommunicate>();
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyCommunicate.currentHealth<=0&&!isDeathed)
		{
			DeathState();
			isDeathed=true;
			nav.enabled=false;

			enemyDirectCommunicate.hudCommunicate.score+=enemyCommunicate.score;
			//物体下沉的控制在动画中指定，动画的事件也属于控制层
			//另外，通过direct交互层，传递信息
			enemyDirectCommunicate.hudCommunicate.hasScore=true;
		}
		if(isSinking)
		{
			transform.Translate (-Vector3.up * enemyCommunicate.sinkSpeed * Time.deltaTime);
		}

	}
	//死亡动画调用
	public void StartSinking()
	{
		GetComponent <Rigidbody> ().isKinematic = true;
		isSinking = true;
		Destroy(gameObject,2f);
	} 
	//死亡状态
	void DeathState()
	{
		capsuleCollider.enabled=false;//死亡状态要将碰撞体取消掉
		anim.SetTrigger("Dead");

		deathAudio.clip=deathClip;
		deathAudio.Play();
	}
}

