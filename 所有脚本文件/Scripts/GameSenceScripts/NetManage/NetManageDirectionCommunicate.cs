using UnityEngine;
using System.Collections;

public class NetManageDirectionCommunicate : MonoBehaviour {
	public HUDCommunicate hudCom;
	// Use this for initialization
	void Awake () {
		hudCom=GameObject.FindWithTag("HUDRoot").GetComponentInChildren<HUDCommunicate>();
	}

}
