using UnityEngine;
using System.Collections;

public class EnemyCommunicate : MonoBehaviour {
    //内部状态交换层
	//属性层
	//一般属性
	public int currentHealth=100;//当前声明值
	//Hurt属性
	public Vector3 hurtPosition;
	public int hurtDamageValue;
	//Death状态
	public int sinkSpeed=3;//死亡下降速度
	public AudioClip deathClip;//死亡的音效

		//idle和Move状态
	public float speed=2f;
		//Attack状态
	public int attackDamage=10;//攻击伤害
	public float timeBetweenAttacks = 0.5f;//攻击频率
	
	//状态属性层，直接控制状态，一一对应。对于复杂的控制层很有必要一一对应状态。
			//这里的状态和状态控制不算复杂，没有严格遵照这个原则
	public bool isDeath=false;//死亡状态
	public bool isHurt=false;//受伤状态
	public bool isAttack=false; //攻击攻击
	public bool isIdle=true;//静止状态
	public bool isMove=false;//移动状态


	///////////////////////////////////
	//外部状态引用
	//因为是实际存在的，而不是实时产生的，
	//所以可以定义在交换层中。实际存在是指，该物体在游戏世界中可以找到。
	//已经把他们放在direct层中。
	//////////////////////////////////
	

	//辅助交换层信息，这些信息属于物体本身，但不需要该物体也能工作。他影响的是其他物体，
		//这里说的其他物体，往往是辅助游戏，让游戏看起来更好的作用。如HUD状态显示
	public int score=10;
}
