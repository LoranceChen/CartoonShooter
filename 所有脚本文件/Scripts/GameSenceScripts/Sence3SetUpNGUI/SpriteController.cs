using UnityEngine;
using System.Collections;

public class SpriteController : MonoBehaviour {
	public SetupMenuDirect stmDir;
	public SetUpGroupCommunicate stupCom;

	public GameObject setupButtonObject;
	public GameObject setupSpriteObject;
	public UILabel pauseLable;
	public UISprite setupSprite;

	bool cantSeeSprite;//辅助截屏效果的实现
	Color aZero=new Color();
	//bool isPauseState;//初始为false，即运行状态.已经转移到setup物体的状态

	public void PauseOrStateState()
	{
		if(stupCom.isPauseState)//当前为暂停状态，点击后变成运行，所以显示文本应为“暂停
		{
			pauseLable.text="Pause";
			stupCom.isPauseState=false;//表示运行状态
			//stmDir.inpCom.needComToPlayer=true;
			Time.timeScale=1;
		}
		else
		{
			pauseLable.text="Start";
			stupCom.isPauseState=true;//暂停状态
			stmDir.inpCom.needComToPlayer=false;//在鼠标响应之前赋值
			print (stmDir.inpCom.needComToPlayer);
			Time.timeScale=0;
		}
	}

	public void ExitState()
	{
		XMLReadAndLoad.Save<MenuSetUpSerialize>(@".\MenuSetUp.xml",MenuSetUpSerialize.GetInstance());
		Application.Quit();
	}

	public  void ScreenShotState()
	{
		//setupSpriteObject.SetActive(false);//这种方式要保证该函数结束时SetActive=true，这样才能执行Onclick的触发事件。
		aZero= setupSprite.color;
		aZero.a=0f;
		setupSprite.color=aZero;

		cantSeeSprite=true;
		//stupCom.switchOpen=false;
		UnityEngine.Application.CaptureScreenshot(@".\ShotScreen.PNG");//貌似是异步
		//setupSprite.color=aZero;

	}
	//按下关闭输入对角色的输入控制，弹起开启控制
	public void OnClickDownState()
	{
		stmDir.inpCom.needComToPlayer=false;
	}
	public void OnClickUpState()
	{
		if(!stupCom.isPauseState)
			stmDir.inpCom.needComToPlayer=true;
		if(cantSeeSprite)
		{
			aZero.a=1f;
			setupSprite.color=aZero;
			cantSeeSprite=false;
		}
	}
	//为PauseAndStart而设定的状态
}
