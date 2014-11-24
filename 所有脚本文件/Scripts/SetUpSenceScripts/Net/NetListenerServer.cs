using UnityEngine;
using System.Collections;

public class NetListenerServer : MonoBehaviour 
{
	public NetManageCommunicate netMagCom;
	public NetManageDirectCommunicate netMagDirCOm;
	//public Transform[] playersTransform;
	//public Color[] playersMainColor;
	//成功建立服务器端时
	void OnServerInitialized()
	{
		Debug.Log("Server initialized and ready");
		netMagCom.roomVolume=netMagDirCOm.mainMenuCom.roomVolume;

	}
	//玩家断开连接时
	void OnPlayerDisconnected(NetworkPlayer player)
	{
		Debug.Log("Clean up after player " + player);
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
		netMagCom.currentRoomVolueme--;
	}
	//玩家连接成功时
	void OnPlayerConnected(NetworkPlayer player)
	{
		Debug.Log("Have a player connected from " + player.ipAddress + ":" + player.port);

		//加入的第一个角色，数组的信息是0
		//networkView.RPC ("MallocViewID",player,"PlayerViewID",Network.AllocateViewID());//给该角色分配一个viewID
		//networkView.RPC ("MallocPosition",player,"PlayerPosition",playersTransform[netMagCom.currentRoomVolueme].position);//给该物体指定一个位置
		//networkView.RPC("MallocNetData",player,"PlayerMaterialMainColor",playersMainColor[netMagCom.currentRoomVolueme]);

		//到达设定的人数限制时跳转。
		if(++netMagCom.currentRoomVolueme==netMagCom.roomVolume)
			netMagCom.isLoadLevel=true;

	}
	//服务端断开时
	void OnDisconnectedFromServer(NetworkDisconnection info)
	{
		if (Network.isServer)
			Debug.Log("Local server connection disconnected");
	}

//	[RPC]
//	void MallocViewID(string objectName,NetworkViewID viewID)//NetworkViewID viewID = Network.AllocateViewID();
//	{
//		NetData.netData.Add(objectName,viewID);
//	}
//	[RPC]
//	void MallocPosition(string objectName,Vector3 position)//NetworkViewID viewID = Network.AllocateViewID();
//	{
//		NetData.netData.Add(objectName,position);
//	}
}
