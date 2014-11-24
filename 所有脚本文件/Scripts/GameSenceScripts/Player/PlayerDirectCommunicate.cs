using UnityEngine;
using System.Collections;

public class PlayerDirectCommunicate : MonoBehaviour {
	//根据自己的状态变动，主动向hud传达信息
	public HUDCommunicate hudCommunicate;
	//public ManageCommunicate manageCommunicate;
	public PlayerLifeCommunicate plyLifCom;
	void Awake()
	{
		hudCommunicate=GameObject.FindGameObjectWithTag("HUDRoot").GetComponentInChildren<HUDCommunicate>();
			print(hudCommunicate);
		//manageCommunicate=GameObject.FindGameObjectWithTag("Manage").GetComponent<ManageCommunicate>();
	//		print(manageCommunicate);
		plyLifCom=GameObject.FindGameObjectWithTag("HUDRoot").GetComponentInChildren<PlayerLifeCommunicate>();
			print(plyLifCom);
	}
}
