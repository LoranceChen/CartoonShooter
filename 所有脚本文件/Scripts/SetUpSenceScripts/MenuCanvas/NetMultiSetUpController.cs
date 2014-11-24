using UnityEngine;
using System.Collections;
public class NetMultiSetUpController : MonoBehaviour 
{
	public MainMenuCommunicate mainMenuCom;
	public MainMenuDirectCommunicate mainMenuDirCom;

	public GameObject multiSetUpUI;
	public GameObject detailCreSetUpUI;
	public GameObject detailLinkSetUpUI;
	public UIInput maxLinkNumInput;
	public UIInput roomNameInput;
	public UIPopupList roomNameList;
	
	int port;
	HostData[] hostListData=null;
	void Update()
	{
		ShowSetUpUIState();//控制显示界面的状态
		
	}
	//显示界面
	void ShowSetUpUIState(){
		if(mainMenuCom.isLoginSuccess)
			multiSetUpUI.SetActive(true);
		else 
			multiSetUpUI.SetActive(false);
	}
	//创建房间按钮的触发状态
	public void ShowCreateRoomUIState()
	{
		detailCreSetUpUI.SetActive(true);
		detailLinkSetUpUI.SetActive(false);
	}
	//接入房间按钮的触发状态
	public void ShowLinkRoomUIState()
	{
		detailCreSetUpUI.SetActive(false);
		detailLinkSetUpUI.SetActive(true);
	}
	//创建按钮的触发状态
	public void CreateRoomState()
	{
		if( Network.peerType == NetworkPeerType.Server )
		//告诉message现在是作为服务器而运行,并直接返回
		{
			mainMenuDirCom.messageCom.msgShowEum=MsgShowEum.OnServerState;
			mainMenuDirCom.messageCom.isMsgShow=true;
			return;
		}

		//现在不是服务器，可能没有在连接，可能是作为Client。无论如何在启动连接之前应该断开连接
		Network.Disconnect();

		int maxPlayer;
		if(System.Int32.TryParse(maxLinkNumInput.value,out maxPlayer)==false||roomNameInput.value=="")
		{
			mainMenuDirCom.messageCom.isMsgShow=true;
			mainMenuDirCom.messageCom.msgShowEum=MsgShowEum.InputFormatError;
			return;
		}
		mainMenuCom.roomVolume=maxPlayer;//通知交互层
		port=NetWorkConfig.netPort;//并不是由用户输入，也不会在运行时改变,而是程序编译后决定，可以认为是安全的。所以不做异常处理了

		print ("创建失败需要做做异常处理！");
		//try{可惜unity没有自己设定异常，返回值不知道怎么用。尝试等于枚举的noerror，结果断网居然成立！
			Network.InitializeServer( maxPlayer, port, !Network.HavePublicAddress() );
		//}
		MasterServer.RegisterHost(NetWorkConfig.gameType,roomNameInput.value);//第三个参数是房主提供的额外信息~~~
	
	}
	//连接按钮的触发状态
	public void LinkRoomState()
	{
		//获取popuplist当前值
		string currentRoomName=roomNameList.value;
		foreach(HostData r in hostListData)
		{
			if(r.gameName==currentRoomName)
			{
				Network.Connect(r);//返回NetworkConnectionError枚举
			}
		}
	}
	public void RefreshDateState()
	{
		MasterServer.RequestHostList(NetWorkConfig.gameType);
	}
	//下拉房间列表触发状态
	public void RoomDataState()
	{
		roomNameList.items.Clear();
		if(MasterServer.PollHostList().Length!=0)
		{
			hostListData=MasterServer.PollHostList();
			foreach(var c in hostListData)
			{
				roomNameList.items.Add(c.gameName);
			}
		}
	}
}
