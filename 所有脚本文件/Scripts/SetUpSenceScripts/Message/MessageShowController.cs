using UnityEngine;
using System.Collections;
/// <summary>
/// 
/// </summary>
public class MessageShowController : MonoBehaviour 
{
	public MessageCommunicate msgCom;
	public float beginAlpha;
	public float aimAlpha;
	public float flashSpeed;

	public UILabel myLable;
	public UISprite msgSprite;

	Color tmpSpriteColor;
	//ShowTweenEnum showTweenEnum;

	void Update()
	{
		if(msgCom.isMsgShow)
		{
			switch(msgCom.msgShowEum)
			{
				case MsgShowEum.LoginSuccess:
					ShowMsgState(msgCom.loginSuccess);
					break;
				case MsgShowEum.LoginFailForPwd:
					ShowMsgState(msgCom.loginFailForPwd);
					break;
				case MsgShowEum.LoginFailForUser:
					ShowMsgState(msgCom.loginFailForUser);
					break;
				case MsgShowEum.RegisterSuccess:
					ShowMsgState(msgCom.registerSuccess);
					break;
				case MsgShowEum.RegisterFail:
					ShowMsgState(msgCom.registerFail);
					break;
				case MsgShowEum.LoginError:
					ShowMsgState(msgCom.loginError);
					break;
				case MsgShowEum.RegisterError:
					ShowMsgState(msgCom.registerError);
					break;
				//input faomat error
				case MsgShowEum.InputFormatError:
					ShowMsgState(msgCom.inputFormatError);
					break;
			}

		}
		else 
		{
			//将msgSprite的alpha改为0
			tmpSpriteColor=msgSprite.color;
			tmpSpriteColor.a=0f;
			msgSprite.color=tmpSpriteColor;
		}

	}

	void ShowMsgState(string msg)
	{
		//对sprite的.a插值
		if(Mathf.Abs(msgSprite.color.a-aimAlpha)>0.001f)
		{
			tmpSpriteColor=msgSprite.color;
			float a=Mathf.Lerp(msgSprite.color.a,aimAlpha,flashSpeed*Time.deltaTime);
			tmpSpriteColor.a=a;
			msgSprite.color=tmpSpriteColor;
			myLable.text=msg;
		}
		else
			msgCom.isMsgShow=false;
	}
	//【问题】如何设计内部状态，将这里值颜色渐变的细分加入淡出效果？当然本来就是动画系统，但动画系统也是程序实现的。
	//public enum ShowTweenEnum{FadeIn,FadeOut,End}
}
