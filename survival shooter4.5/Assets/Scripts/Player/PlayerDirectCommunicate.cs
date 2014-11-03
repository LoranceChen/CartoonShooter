using UnityEngine;
using System.Collections;

public class PlayerDirectCommunicate : MonoBehaviour {
	//根据自己的状态变动，主动向hud传达信息
	public HUDCommunicate hudCommunicate;
	public ManageCommunicate manageCommunicate;
	void Awake()
	{
		//hudCommunicate=GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDCommunicate>();
		//print(hudCommunicate);
		manageCommunicate=GameObject.FindGameObjectWithTag("Manage").GetComponent<ManageCommunicate>();
	}
}
