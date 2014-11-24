using UnityEngine;
using System.Collections;
/// <summary>
///非本地时，在此控制角色的所有状态 .
/// </summary>
public class PlayerNetController : MonoBehaviour {
	public PlayerCommunicate playerCom;
	//将player需要的信息都传输
	Vector3 readNetworkPos=new Vector3();
	bool isNetFire;
	//bool isNetFire;
	// Use this for initialization
	void Update()
	{
		//isNetFire=playerCom.isFire;
		if(!networkView.isMine)
		{
			transform.position=Vector3.Lerp(transform.position,readNetworkPos,10f*Time.deltaTime);
		}
	}
	void OnSerializeNetworkView( BitStream stream )
	{
		// writing information, push current paddle position
		//print ("hello OnSerializeNetworkView");
		if( stream.isWriting )
		{
///			print ("WriteInfo");
			Vector3 pos = transform.position;
			isNetFire=playerCom.isFire;
			stream.Serialize( ref pos );
			stream.Serialize( ref isNetFire );
		}
		// reading information, read paddle position
		else
		{
//			print ("reading info");
			Vector3 pos = Vector3.one;
			stream.Serialize( ref pos );
			stream.Serialize( ref isNetFire );
			readNetworkPos = pos;
			//transform.position=pos;
			playerCom.isFire=isNetFire;
		}
	}
}
