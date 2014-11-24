using UnityEngine;
using System.Collections;

public class NetListenerClient : MonoBehaviour 
{
	//连接到服务器时
	void OnConnectedToServer()
	{
		Debug.Log("Connected to server");

	}
	/// <summary>
	///连接失败 
	/// </summary>
	void OnFailedToConnect(NetworkConnectionError error)
	{
		Debug.Log("Could not connect to server: " + error);
	}
	/// <summary>
	/// 连接后断开	
	/// </summary>
	void OnDisconnectedFromServer(NetworkDisconnection info)
	{
		if (info == NetworkDisconnection.LostConnection)
			Debug.Log("Lost connection to the server");
		else
			Debug.Log("Successfully diconnected from the server");
	}
}
