using UnityEngine;
using System.Collections;
/// <summary>
///分类为服务器和客户端 
/// </summary>
public class NetGameManage : MonoBehaviour {
	public NetManageDirectionCommunicate netMagDirCom;
	public GameObject player;
	public GameObject manage;
	//public GameObject InputObject;
	//public PlayerCommunicate playerCom;
	//public NetworkView playerNetworkView;
	// Use this for initialization
	Vector3 clientVec=new Vector3(1f,0f,1f);

	void Start()
	{
		//dir
		netMagDirCom=GetComponent<NetManageDirectionCommunicate>();
		//网络相关的初始化控制
		OccurPlayerController();
		OccurManageController();
		//联网情况才会启动
		if(Network.peerType==NetworkPeerType.Client||Network.peerType==NetworkPeerType.Server)
			StartCoroutine("PlayerNetWin");
	}
	/// <summary>
	///根据网络信息判断以何种方式产生玩家 
	/// </summary>
	void OccurPlayerController()
	{
		if(Network.peerType==NetworkPeerType.Server)
			Network.Instantiate(player,Vector3.zero,Quaternion.identity,0);//第四个参数是什么
		else if(Network.peerType==NetworkPeerType.Client)
			Network.Instantiate(player,clientVec,Quaternion.identity,0);
		else//单机
			Instantiate(player,Vector3.zero,Quaternion.identity);
	}
	/// <summary>
	///根据网络信息决定如何控制场景。 
	/// </summary>
	void OccurManageController()
	{
		if(Network.peerType==NetworkPeerType.Disconnected)
			manage.SetActive(true);
		else
			manage.SetActive(false);
	}
	/// <summary>
	/// 协同程序判断场景中只有一个玩家时胜利。
	/// </summary>
	IEnumerator PlayerNetWin()
	{
		yield return new WaitForSeconds(7f);
		bool isWin=false;
		//Object allPlayer;
		int playerCount=0;
		while(!isWin)
		{
			yield return new WaitForSeconds(2f);
			//netMagDirCom.hudCom.
			//如果只有一个Player tag标签的物体时，触发
			GameObject[] allPlayer= GameObject.FindGameObjectsWithTag("Player");
			foreach(var p in allPlayer)
			{
				//当遍历的当前玩家的生命值大于0时，表示有一个玩家存活，并计数
				if(p.GetComponent<PlayerCommunicate>().currentHealth>0)
				{
						playerCount++;
				}		
			}
			print ("playerCount:"+playerCount);
			if(playerCount==1)
				netMagDirCom.hudCom.isPlayerWin=true;
			else 
				playerCount=0;
		}
	}
/*	void Awake()
	{
		//服务器端只要告诉其他玩家创建一个相同的物体就可以了
		if(Network.peerType==NetworkPeerType.Server)
		{
			//playerCom.gameObject.GetComponent<NetworkView>().viewID=(NetworkViewID)NetData.netData["PlayerViewID"] ;
			StartCoroutine("OccurPlayer");
		}
		//客户端要确定同步的位置，更改本地ID
		else if(Network.peerType==NetworkPeerType.Client)
		{
			playerCom.gameObject.GetComponent<NetworkView>().viewID=(NetworkViewID)NetData.netData["PlayerViewID"] ;
			StartCoroutine("OccurPlayer");
		}
	}
	IEnumerator OccurPlayer () 
	{
		yield return new WaitForSeconds(4f);
		if(Network.peerType==NetworkPeerType.Client||Network.peerType==NetworkPeerType.Server)
		{
		
			networkView.RPC("SynchronousPlayer",RPCMode.OthersBuffered)	;	

		}
	}
	[RPC]
	void SynchronousPlayer()
	{
		print ("RPCalling");
		//在其他角色上初始化一个角色。
		if(Network.peerType==NetworkPeerType.Server)
			Instantiate(player,playerCom.transform.position,Quaternion.identity);
		else
		{
			Instantiate(player,(Vector3)NetData.netData["PlayerPosition"],Quaternion.identity);
			print ("Cilent RPCalling");
		}
	}
	*/
}
