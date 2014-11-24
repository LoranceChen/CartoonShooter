using UnityEngine;
using System.Collections;

public class SetupDiffcultyController : MonoBehaviour {
	public UIToggle eyToggle;
	public UIToggle midToggle;
	public UIToggle difToggle;

//	bool isInitToggle;
	// Use this for initialization
	void Awake ()
	{

	//	isInitToggle=true;
		//print ("isInitToggle:"+isInitToggle);
		MenuSetUpSerialize ms=MenuSetUpSerialize.GetInstance();
		//ms.difficultyLevel=3;
		//这里怎么响应事件的？
		if(ms.difficultyLevel==1)
		{
			eyToggle.value=true;
			midToggle.value=false;
			difToggle.value=false;
		}
		if(ms.difficultyLevel==2)
		{	
			eyToggle.value=false;
			midToggle.value=true;
			difToggle.value=false;
		}
		if(ms.difficultyLevel==3)
		{	
			eyToggle.value=false;
			midToggle.value=false;
			difToggle.value=true;
		}
	}
	
	// Update is called once per frame
	public void DifLevelController()
	{
//		if(isInitToggle)
//		{
//			isInitToggle=false;
//			return;
//		}
		MenuSetUpSerialize msus= MenuSetUpSerialize.GetInstance();
		print(msus.difficultyLevel);
		if(eyToggle.value==true)
			msus.difficultyLevel=1;
		else if(midToggle.value==true)
			msus.difficultyLevel=2;
		else if(difToggle.value==true)
			msus.difficultyLevel=3;
	}
}
