using UnityEngine;
using System.Collections;

public class EnemyDirectCommunicate : MonoBehaviour {
	//直接交换层————记录环境中科指定物体的变量，这里的变量要求在一开始能够指定
		//他的值，并且不会由外部环境获取。单向信息交流
	//联系Player
	//player在环境中是可以找到的，而不是实时产生或出现
	public PlayerCommunicate playerCommunicate;
	public HUDCommunicate hudCommunicate;
	void Awake()
	{
		//指定了环境中存在的player.以后可能会加入Update，他可以一直搜索实时控制环境中的palyer
		//但find方法比较慢。实时搜寻关联比较慢，所以当作一个特殊用法。或者在状态反馈时关联该对象。																								//状态反馈不属于这里的业务。
		playerCommunicate=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCommunicate>();
		hudCommunicate=GameObject.FindGameObjectWithTag("HUDRoot").GetComponentInChildren<HUDCommunicate>();
	}
}
