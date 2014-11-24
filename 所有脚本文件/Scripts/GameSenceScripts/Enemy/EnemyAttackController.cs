using UnityEngine;
using System.Collections;

public class EnemyAttackController : MonoBehaviour {
	EnemyDirectCommunicate enemyDirectCommunicate;
	EnemyCommunicate enemyCommunicate;
	//中间变量
	PlayerCommunicate playerCommunicate;
	bool playerInRange=false;
	float timeBetweenAttacks;
	float timer;
	void Awake()
	{
		enemyCommunicate=GetComponent<EnemyCommunicate>();
	}
	void Start()
	{
		//dierct层中信息的关联
		enemyDirectCommunicate=GetComponent<EnemyDirectCommunicate>();
		//设定中间变量，并初始化
		playerCommunicate=enemyDirectCommunicate.playerCommunicate;
		timeBetweenAttacks=enemyCommunicate.timeBetweenAttacks;
		timer=0f;
	}

	void Update()
	{
		timer+=Time.deltaTime;
		//玩家在范围内，上次攻击的时间间隔超过了设定
		if(playerInRange&&timer>=timeBetweenAttacks)
		{
			AttackState();
			//通知玩家被攻击了。
			playerCommunicate.isHurt = true;
			playerCommunicate.hurtDamageValue=enemyCommunicate.attackDamage;
			//攻击之后设定timer重新从0开始计数
			timer=0f;
		}
	}
	//控制中间变量
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag== "Player")
		{
			playerInRange = true;
		}
	}
	//控制中间变量
	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag== "Player")
		{
			playerInRange = false;
		}
	}

	//攻击状态
	void AttackState()
	{
		//暂时没有
	}
}
