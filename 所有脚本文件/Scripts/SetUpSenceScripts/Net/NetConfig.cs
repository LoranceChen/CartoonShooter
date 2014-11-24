using UnityEngine;
using System.Collections;

public class NetConfig : MonoBehaviour 
{

	void Awake()
	{
		MasterServer.ipAddress=NetWorkConfig.masterServerIP;
		MasterServer.port=NetWorkConfig.masterServerPort;
		Network.natFacilitatorIP=NetWorkConfig.masterNATIp;
		Network.natFacilitatorPort=NetWorkConfig.masterNATPort;
	}
}
