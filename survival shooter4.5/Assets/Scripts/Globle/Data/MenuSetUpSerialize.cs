using UnityEngine;
using System.Collections;
using System.Xml;


//[System.Serializable]
public class MenuSetUpSerialize 
{
	private MenuSetUpSerialize(){
		//构造函数初始化单例
		backMusicVolume=.4f;
		efSoundVolume=.4f;
		difficultyLevel=1;
	}//不可通过构造函数实例化
	public static MenuSetUpSerialize msts=null;

	public float backMusicVolume;
	public float efSoundVolume;
	public int difficultyLevel;

	public static MenuSetUpSerialize GetInstance()
	{
		if(msts==null)
		{
			//初始化一个唯一的实例
			msts =new MenuSetUpSerialize();
				//XMLReadAndLoad.Load<MenuSetUpSerialize>(@".\MenuSetUp.xml");//new MenuSetUpSerialize();// 
		}
		return msts;
	}
	public void CopyValue(MenuSetUpSerialize src)
	{
		this.backMusicVolume= src.backMusicVolume;
		this.efSoundVolume=src.efSoundVolume;
		this.difficultyLevel=src.difficultyLevel;
	}
}

