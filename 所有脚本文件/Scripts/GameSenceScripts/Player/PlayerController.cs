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

	//network
	//Vector3 readNetworkPos =new Vector3();
	bool isNetFire;
	bool isNetHurt;
	float netHInput;
	float netVInput;
	//Vector3 netPosition=new Vector3();
	Vector3 netPlayerToMouse=new Vector3();
	//Quaternion netPlayerQatn;//=new Quaternion();
	void Awake () {
        playerCommunicate = GetComponent<PlayerCommunicate>();
        playerState = GetComponent<PlayerState>();
		//netPlayerQatn=transform.rotation;
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
		///联网的本机或单机
		if(networkView.isMine||Network.peerType== NetworkPeerType.Disconnected)
		{
				if(playerCommunicate.currentHealth>0)
	        	ShootingController();
	        //控制玩家移动
				//玩家还有生命
			if(playerCommunicate.currentHealth>0)
	        	TransformController();

			//save fire

		}
		//联网的镜像
		else if(!networkView.isMine&&(Network.peerType==NetworkPeerType.Client||Network.peerType==NetworkPeerType.Server))
		{
			//移动
			//有动画，但是同步状况不佳
			playerCommunicate.hInput=netHInput;
			playerCommunicate.vInput=netVInput;
			//镜像的插值位置处理,没有动画
			//transform.position=Vector3.Lerp(transform.position,netPosition,5f*Time.deltaTime);
			playerCommunicate.playerToMouse=netPlayerToMouse;
			TransformController() ;
			//fire
			playerCommunicate.isFire=isNetFire;
			//射击之前同步旋转
			//transform.rotation=netPlayerQatn;
			ShootingController();
		}
		//控制死亡状态
		if(playerCommunicate.currentHealth<=0)
			Die();
		//控制受伤状态
		if(playerCommunicate.isHurt&&playerCommunicate.currentHealth>0)
		{
			GetHurt();
			//direct层
			//网络分类处理，镜像物体不做UI显示
			if(!networkView.isMine&&(Network.peerType==NetworkPeerType.Client||Network.peerType==NetworkPeerType.Server))
				return;
			//本地物体,显示UI

				playerDirectCommunicate.hudCommunicate.isHurtEffects=true;
			//playerDirectCommunicate.hudCommunicate.playerHeartSlider=playerCommunicate.currentHealth;
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
				//射击状态,包含了反馈,称为状态反馈
				shootHit=playerState.ShootingState(playerCommunicate.damageShoot, playerCommunicate.range,playerCommunicate.shootableMask);
				//射中敌人
				if(shootHit.collider.tag=="Enemy")//做一个异常处理
				{	
					if(shootHit.collider.GetComponent<EnemyCommunicate>().currentHealth>0)
					{
						//这是对外界反应的实时反馈。这里获取外界环境不是通过交换层，而是通过状态反馈信息的数据
						shootHit.collider.GetComponent<EnemyCommunicate>().isHurt=true;//注意enemy处理完信息后要改回false。
						shootHit.collider.GetComponent<EnemyCommunicate>().hurtPosition=shootHit.point;
						shootHit.collider.GetComponent<EnemyCommunicate>().hurtDamageValue=playerCommunicate.damageShoot;
					}
				}
				//射中玩家
				if(shootHit.collider.tag=="Player")
				{
					//通知player他受到伤害了，以及伤害点数
					shootHit.collider.GetComponent<PlayerCommunicate>().isHurt=true;
					shootHit.collider.GetComponent<PlayerCommunicate>().hurtDamageValue=playerCommunicate.damageShoot;
					//得分
					//如果是本地的话，就要加分
					if(networkView.isMine||Network.peerType== NetworkPeerType.Disconnected)
					{
						playerDirectCommunicate.hudCommunicate.score+=playerCommunicate.hurtDamageValue;
						playerDirectCommunicate.hudCommunicate.hasScore=true;
					}
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
				//镜像不做UI处理
			if(!networkView.isMine&&(Network.peerType==NetworkPeerType.Client||Network.peerType==NetworkPeerType.Server))
				return;
				//本地物体需要处理UI
			playerDirectCommunicate.hudCommunicate.isGameOver=true;
			//playerDirectCommunicate.hudCommunicate.playerHeartSlider=0;
			playerDirectCommunicate.hudCommunicate.changeHealth=true;
	}

	void OnSerializeNetworkView( BitStream stream )
	{
		if( stream.isWriting )
		{
			print ("WriteInfo");
			//controller fire
			isNetFire=playerCommunicate.isFire;
			//mouse
			netPlayerToMouse=playerCommunicate.playerToMouse;
			//input
			netHInput=playerCommunicate.hInput;
			netVInput=playerCommunicate.vInput;
			//transform
			//netPosition=transform.position;
			//netPlayerQatn=transform.rotation;
			//serialize
			stream.Serialize( ref netHInput );
			stream.Serialize( ref netVInput );
			//stream.Serialize( ref netPosition );
			stream.Serialize( ref netPlayerToMouse );
			//stream.Serialize( ref netPlayerQatn );
			stream.Serialize( ref isNetFire );
		}
		// reading information, read paddle position
		else//读数据
		{
			print ("reading info");
//			stream.Serialize( ref pos );
//			stream.Serialize( ref isNetFire );
//			readNetworkPos = pos;
////			print ("readNetworkPos:"+readNetworkPos);pass
//			//transform.position=pos;
//			playerCommunicate.isFire=isNetFire;
//			print ("isFire:"+playerCommunicate.isFire);

			stream.Serialize( ref netHInput );
			stream.Serialize( ref netVInput );
			//stream.Serialize( ref netPosition );
			stream.Serialize( ref netPlayerToMouse );
			stream.Serialize( ref isNetFire );
			//stream.Serialize( ref netPlayerQatn );
		}
	}
}
