using UnityEngine;
using System.Collections;

public class HUDHurtEffectsController : MonoBehaviour {
	HUDCommunicate hudCommunicate;
	//HUDDirectCommunicate hudDirectCommunicate;
	public UISprite damageSprite;//属于物体内的资源

	//中间变量

	void Awake()
	{
		hudCommunicate=GetComponent<HUDCommunicate>();
	}
	void Update()
	{
		//这里不能监听，因为如果player是ishurt会被运行update被处理到false，player从ishurt的true到false是原子状态不可被分割。只能用玩家direct给HUD
		//if(hudDirectCommunicate.playerCommunicate.isHurt)//&&hudCommunicate.isHurtEffects==false);//发现监听物体受伤了，触发了自己的状态
		//	hudCommunicate.isHurtEffects=true;//为了响应交互层，要求用交互层的状态转有参数控制。其实直接用player也可以。不过这是原则
		//满足触发条件,很难理解
		if(hudCommunicate.isHurtEffects)
			damageSprite.color=hudCommunicate.flashColor;//触发一次上海进行重置一次闪烁
		else 
			HurtEffectsState(hudCommunicate.flashSpeed);//每次都会闪烁，只是插值后看不出在闪而已。实际不应如此
		hudCommunicate.isHurtEffects=false;
	}

	void HurtEffectsState(float flashSpeed)//,Color flashColor)
	{
		damageSprite.color = Color.Lerp(damageSprite.color,Color.clear,flashSpeed*Time.deltaTime);
	}
}
