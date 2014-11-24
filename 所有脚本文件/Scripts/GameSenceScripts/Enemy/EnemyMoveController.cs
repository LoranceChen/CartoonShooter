using UnityEngine;
using System.Collections;

public class EnemyMoveController : MonoBehaviour {
	NavMeshAgent nev;
	EnemyCommunicate enemyCommunicate;
	EnemyDirectCommunicate enemyDirectCommunicate;
	//中间变量
	Transform player;

	void Awake()
	{
		nev=GetComponent<NavMeshAgent>();
		enemyCommunicate=GetComponent<EnemyCommunicate>();
		enemyDirectCommunicate=GetComponent<EnemyDirectCommunicate>();
	}
	// Use this for initialization
	void Start () {//为了在direct层关联之后使用，这里务必在Start()中关联组件
		//player是没有通过交换层使用了外部变量
			//这里有个疑问：是在交换层关联Player还是在控制层和状态层关联？
			//交换层是用来交换数据，自己用的到的数据和别人用的到的数据。从这点来说，Player只有自己用的到，
			//所以写在交换层会让外部感到困惑——为什么Enemy会有PlayerTransform的属性
			//但是写在这里也有些不妥，因为player可以在环境中指定，他是实际存在的而不是实时产生的。
			//所以这一类变量称作外部交换层，仅仅为了自己关联其他存在的事物
			//最终决定建立DirectCommunicate的概念
		//direct层的数据传递
		//player = ;
	}
	
	// Update is called once per frame
	void Update () {
		//寻路控制,有生命值才寻路。死亡时不能寻路
		if(enemyCommunicate.currentHealth>0)//nev.enabled&&
			SeedRoad();
		else //否则不寻路
			nev.enabled=false;
	}
	//寻路状态
	void SeedRoad()
	{
		nev.SetDestination(enemyDirectCommunicate.playerCommunicate.transform.position);
	}
}
