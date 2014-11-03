using UnityEngine;
using System.Collections;

public class SetupCommunicate : MonoBehaviour 
{
	public bool needBackMusic;
	public bool needEffectsSounds;
	public bool needDifficultyLevel;
	public bool needBackButton;

	public bool isButtonDown;
	public float backMusicVolume;
	public float effectsSoundVolume;
	public int difficultLevel;//从小到大难度增加
	public void IsButtonDown()//用于button事件的触发函数，为什么不能触发变量。
	{
		isButtonDown=true;
	}
}
