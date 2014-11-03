using UnityEngine;
using System.Collections;

public class InputDirectCommunicate : MonoBehaviour {
	public PlayerCommunicate playerCommunicate;
	//除了在Awake中指定要交流的外界对象外，还可以public方式在inspector中初始化
	void Awake()
	{
		playerCommunicate=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCommunicate>();
	}
}
