using UnityEngine;
using System.Collections;

public class NetMenuLogAndRegController : MonoBehaviour {
	public MainMenuCommunicate mainMenuCom;
	public MainMenuDirectCommunicate mainMenuDirCom;
	public UIInput userNameInput;
	public UIInput pwdInput;
	public GameObject LoginUI;

	public void LoginState()
	{
		string user=userNameInput.value;
		string pwd=pwdInput.value;
		WWWForm form=new WWWForm();
		form.AddField("user",user);
		form.AddField("password",pwd);
		WWW w=new WWW("http://lorance.myartsonline.com/DataBase/login.php",form);
		StartCoroutine(Login(w));

	}
	IEnumerator Login(WWW w)
	{
		yield return w;
		if(w.error==null)
		{
			if(w.text=="login-SUCCESS")
			{
				mainMenuDirCom.messageCom.isMsgShow=true;
				mainMenuDirCom.messageCom.msgShowEum=MsgShowEum.LoginSuccess;
				mainMenuCom.isLoginSuccess=true;
				LoginUI.SetActive(false);
			}
			else if(w.text=="Password doesn't match!")//验证一下
			{
				mainMenuDirCom.messageCom.isMsgShow=true;
				mainMenuDirCom.messageCom.msgShowEum=MsgShowEum.LoginFailForPwd;
			}
			else if(w.text=="Username doesn't exist!")//验证一下
			{
				mainMenuDirCom.messageCom.isMsgShow=true;
				mainMenuDirCom.messageCom.msgShowEum=MsgShowEum.LoginFailForUser;
			}
		}
		else
		{
			mainMenuDirCom.messageCom.isMsgShow=true;
			mainMenuDirCom.messageCom.msgShowEum=MsgShowEum.LoginError;
		}
	}
	public void RegisterState()
	{
		string user=userNameInput.value;
		string pwd=pwdInput.value;
		WWWForm form=new WWWForm();
		form.AddField("user",user);
		form.AddField("password",pwd);
		WWW w=new WWW("http://lorance.myartsonline.com/DataBase/register.php",form);
		StartCoroutine(Register(w));
	}
	IEnumerator Register(WWW w)
	{
		yield return w;
		if(w.error==null)
		{
			if(w.text=="Successfully")
			{
				mainMenuDirCom.messageCom.isMsgShow=true;
				mainMenuDirCom.messageCom.msgShowEum=MsgShowEum.RegisterSuccess;
			}

			else if(w.text=="User allready exist")
			{
				mainMenuDirCom.messageCom.isMsgShow=true;
				mainMenuDirCom.messageCom.msgShowEum=MsgShowEum.RegisterFail;
			}
		}
		else
		{
			mainMenuDirCom.messageCom.isMsgShow=true;
			mainMenuDirCom.messageCom.msgShowEum=MsgShowEum.RegisterError;
		}
	}
}
