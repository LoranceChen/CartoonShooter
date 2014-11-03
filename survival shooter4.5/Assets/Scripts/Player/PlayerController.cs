using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    //物体内部组件交流用private，因为不会经常变动。而且数量会很多，public经常拖动很麻烦。
        //其实unity最好能识别物体内部组件的引用，定义成public但不要显示在inspector中，这样既有了public的引用效率，
        //  也有了getcomponent的方便（少数的public拖动比较方便，但多了的话脚本反而更方便）。没用的信息也不会影响界面。
    PlayerCommunicate playerCommunicate;
	PlayerDirectCommunicate playerDirectCommunicate;
    PlayerState playerState;

    //中间变量
    float timer = 0f;//记录射击时间隔
	RaycastHit shootHit;//射击的碰撞体信息

	void Awake () {
        playerCommunicate = GetComponent<PlayerCommunicate>();
        playerState = GetComponent<PlayerState>();

	}
	void Start()
	{
		//direct
		playerDirectCommunicate=GetComponent<PlayerDirectCommunicate>();
//		print(playerDirectCommunicate);
		//只能在主线程中初始化的交互层变量。
		playerCommunicate.shootableMask = LayerMask.GetMask("Shootable");


	}
	
	// Update is called once per frame
	void Update () {
		//控制射击状态
		if(playerCommunicate.currentHealth>0)
        	ShootingController();
        //控制玩家移动
			//玩家还有生命
		if(playerCommunicate.currentHealth>0)
        	TransformController();
		//控制死亡状态
		if(playerCommunicate.currentHealth<=0)
			Die();
		//控制受伤状态
		if(playerCommunicate.isHurt&&playerCommunicate.currentHealth>0)
		{
			GetHurt();
			//direct层
			playerDirectCommunicate.hudCommunicate.isHurtEffects=true;
			playerDirectCommunicate.hudCommunicate.playerHeartSlider=playerCommunicate.currentHealth;
			playerDirectCommunicate.hudCommunicate.changeHealth=true;
		}
	}
    //控制发射
    void ShootingController()
    {
        timer += Time.deltaTime;
        //控制子弹发射状态
        if (playerCommunicate.isFire && timer >= playerCommunicate.timeBetweenBullets)
        {
            timer = 0;
			//射击状态,包含了反馈
			shootHit=playerState.ShootingState(playerCommunicate.damageShoot, playerCommunicate.range,playerCommunicate.shootableMask);
			if(shootHit.collider.tag=="Enemy"&&shootHit.collider.GetComponent<EnemyCommunicate>().currentHealth>0)
			{
				//这是对外界反应的实时反馈。这里获取外界环境不是通过交换层，而是通过状态反馈信息的数据
				shootHit.collider.GetComponent<EnemyCommunicate>().isHurt=true;//注意enemy处理完信息后要改回false。
				shootHit.collider.GetComponent<EnemyCommunicate>().hurtPosition=shootHit.point;
				shootHit.collider.GetComponent<EnemyCommunicate>().hurtDamageValue=playerCommunicate.damageShoot;
			}
        }
        //控制子弹发射状态的参数
        if (timer >= playerCommunicate.timeBetweenBullets * playerCommunicate.effectsDisplayTime)//[问题]为什么相乘？？？？
		{//特效关闭的时间与子弹间隔和特效关闭时间系数有关
            playerState.DisableEffects();
        }
    }
    //控制移动
    void TransformController() //移动控制了两个状态，并实现旋转控制。没有设定旋转为一个状态，而把它当作控制来使用
    {
        if (playerCommunicate.hInput== 0&&playerCommunicate.vInput==0)
        {
            playerState.IdleState();
        }
       else //其中一个方向不为0，
           {
                //将物体状态这设定为MoveState
                playerState.MoveState(playerCommunicate.playerMoveSpeed, playerCommunicate.hInput, playerCommunicate.vInput);
           }
		//旋转控制
		TransformRotation();
    }
    //控制移动的子控制——旋转控制
    void TransformRotation() 
    {
		if(playerCommunicate.playerToMouse!=Vector3.zero)
		{
			Quaternion newRotation = Quaternion.LookRotation(playerCommunicate.playerToMouse);//根据一个方向，返回一个旋转
            rigidbody.MoveRotation(newRotation);
		}
	}
	//控制受伤
	void GetHurt()
	{
		playerCommunicate.currentHealth-=playerCommunicate.hurtDamageValue;
		playerState.HurtStart();
		playerCommunicate.isHurt=false;//一定要改过来，也说明了不受伤的条件是：受过伤

	}
	//控制死亡
	void Die()
	{
			playerState.DieState();
			//direct层发送信息
			playerDirectCommunicate.hudCommunicate.isGameOver=true;
			//playerDirectCommunicate.hudCommunicate.playerHeartSlider=0;
			playerDirectCommunicate.hudCommunicate.changeHealth=true;
	}
}
