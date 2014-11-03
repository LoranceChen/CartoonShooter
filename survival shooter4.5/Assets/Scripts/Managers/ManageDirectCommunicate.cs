using UnityEngine;
using System.Collections;

public class ManageDirectCommunicate : MonoBehaviour {
	public HUDCommunicate hudCommunicate;//声明为public方便观察
								//在inspector中可以看到该物体直接传输数据到哪个物体

	void Awake()
	{
		hudCommunicate=GameObject.FindGameObjectWithTag("HUDRoot").GetComponentInChildren<HUDCommunicate>();
	}
}
