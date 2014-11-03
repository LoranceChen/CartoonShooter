using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {
	public SetupMenuDirect stmDir;
	public SetUpGroupCommunicate stupCom;
	//bool switchOpen;
	//public GameObject SetupButton;
	public GameObject SetupFuc;
	public void SetupMenuState(){
		if(!stupCom.switchOpen)
		{
			//SetupButton.SetActive(false);
			SetupFuc.SetActive(true);
			stupCom.switchOpen=true;
		}
		else
		{
			//SetupButton.SetActive(true);
			SetupFuc.SetActive(false);
			stupCom.switchOpen=false;
		}
	}
	//按下和弹起鼠标时的状态
	public void OnClickDownState()
	{
		//
		stmDir.inpCom.needComToPlayer=false;
	}
	public void OnClickUpState()
	{
		if(!stupCom.isPauseState)
			stmDir.inpCom.needComToPlayer=true;
	}
}
