using UnityEngine;
using System.Collections;

public class MessageCommunicate : MonoBehaviour {
	public bool isMsgShow;//显示信息状态
	public MsgShowEum msgShowEum;
	public string loginSuccess;
	public string loginFailForPwd;//密码错误
	public string loginFailForUser;//账号不存在
	public string loginError;
	public string registerSuccess;
	public string registerFail;
	public string registerError;
	//输入格式错误
	public string inputFormatError;
}
public enum MsgShowEum
{
	//net relation
	LoginSuccess,
	LoginFailForPwd,
	LoginFailForUser,
	LoginError,
	RegisterSuccess,
	RegisterFail,
	RegisterError,
	//format
	InputFormatError,
	//现在是一个服务器
	OnServerState
}