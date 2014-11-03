using UnityEngine;
using System.Collections;

public class EnemyIdleController : MonoBehaviour {
	Animator anim;
	//EnemyCommunicate enemyCommunicate;
	EnemyDirectCommunicate enemyDirectCommunicate;

	//中间变量，为了方便而设定的变量
	// Use this for initialization
	void Awake () {//虽然因为direct层的限制，但awake中依然可以关联自己的组件
		anim=GetComponent<Animator>();
		//enemyCommunicate=GetComponent<EnemyCommunicate>();
		enemyDirectCommunicate=GetComponent<EnemyDirectCommunicate>();
	}
	// Update is called once per frame
	void Update () {
		if( enemyDirectCommunicate.playerCommunicate.currentHealth<=0)
		{
			IdleState();
		}
	}

	//idle状态
	void IdleState()
	{
		anim.SetTrigger("PlayerDead");
	}
}
