using UnityEngine;
using System.Collections;

public class PlayerToLifeShowController : MonoBehaviour {
	public PlayerCommunicate plCom;
	public PlayerDirectCommunicate plDirCom;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		//传入的是本地物体的信息
		//只有物体处于本地或者是断网状态下才会和HUD交流。
		if(networkView.isMine||Network.peerType==NetworkPeerType.Disconnected)
		{
			plDirCom.plyLifCom.slideValue=(float)plCom.currentHealth/plCom.fullHealth;
		}
	}
}
