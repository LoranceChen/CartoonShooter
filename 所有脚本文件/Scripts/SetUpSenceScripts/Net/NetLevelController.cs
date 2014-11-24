using UnityEngine;
using System.Collections;

public class NetLevelController : MonoBehaviour 
{
	public NetManageCommunicate netMagCom;

	// Update is called once per frame
	void Update () {
		if(netMagCom.isLoadLevel)
		{
			//通知所有玩家载入新场景
			networkView.RPC("LoadLevelState",RPCMode.All);
			netMagCom.isLoadLevel=false;
		}
	}
	//载入信息场景
	[RPC]
	void LoadLevelState()
	{
		NetworkLevelLoader.Instance.LoadLevel( "MainGameNGUI" );
	}
}
