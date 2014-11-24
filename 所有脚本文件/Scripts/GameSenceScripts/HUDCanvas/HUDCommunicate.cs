using UnityEngine;
using System.Collections;

public class HUDCommunicate : MonoBehaviour {
	//该物体用于显示数据，所有显示的信息放在这个HUD物体中
	//得分属性层
	public int score=0;
	//生命显示属性层
	//public int playerHeartSlider=100;//玩家当前生命，现在用不到，以后可能会显示玩家血量用到
	
	//hurteffects属性层
	public Color flashColor=new Color(1.0f,0f,0f,0.1f);
	public float flashSpeed=4f;

	//直接状态控制变量,这些bool变量直观，明确每个状态对应一个变量，即使用不上也不会拖后腿
	public bool isHurtEffects=false;
	public bool hasScore=false;
	public bool changeHealth=false;
	public bool isGameOver=false;
	public bool isPlayerWin=false;
}
