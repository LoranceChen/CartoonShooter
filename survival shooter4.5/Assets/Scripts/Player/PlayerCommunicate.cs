using UnityEngine;
using System.Collections;

public class PlayerCommunicate : MonoBehaviour {
    //传入交互层，外界对自己的影响。
        //考虑和控制层的关系，将相关的数据写在一个结构中，如：struct ShootingSrutct{...}
    //shooting控制方面的变量
    public float timeBetweenBullets=0.15f;//子弹发射间隔，以后吃了东西可能会改变该参数
    public int range = 100;//射击距离 shootingState调节参数 
    public int damageShoot = 20;//射击伤害 shootingState调节参数 
    public float effectsDisplayTime = 0.2f;//控制特效时间 控制层
	public int shootableMask;// = LayerMask.GetMask("Shootable");//射击目标物体的层,这个只能在主线程中调用
																	//update，awake等叫主线程
    //玩家移动方面的变量
    public float playerMoveSpeed=6f;//玩家速度
    public float hInput;//水平x
    public float vInput;//上下z
    public Vector3 playerToMouse;//鼠标的位置
	public bool isFire;//是否开火
    //交互层对输入做出相应，本来输入作为外界环境，有输入物体控制hInput，vInput。但这里放在交互层中队输入做出相应。
        //对于输入来讲，unity已经将输入，控制，响应写在inputSysytem中了
        //但考虑到以后不同的输入对h，v的影响，还是将输入对h，v的影响写在专门的控制中。
        //也就是说输入不写在这里了，（本来就不该写在这里）
	//生命值变量，传递给受伤层，死亡层，射击层，移动层
	public int fullHealth=100;
	public int currentHealth=100;
	//受伤变量，传递给受伤控制层
	public bool isHurt=false;
	public int hurtDamageValue=20;//受到的伤害

}
