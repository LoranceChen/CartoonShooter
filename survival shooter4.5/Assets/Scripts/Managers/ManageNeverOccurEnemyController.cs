using UnityEngine;
using System.Collections;

public class ManageNeverOccurEnemyController : MonoBehaviour {
	ManageCommunicate manageCommunicate;
	ManageDirectCommunicate manageDirectCommunicate;
	//只与控制层相关的可变变量，这种变量一般为public，表明它是可变的。秉承细胞模式一切可变的思想，只要存在环境中，影响状态的都设定为public，也许现在用不到
		//而中间变量为private，因为只是为了记录数据
	//这个变量不在交换层设定是因为目前找不到理由，在这个世界观中为什么要改变调用的时间间隔。
	public float swapTime=1.5f;
	private bool isNever;//本来不定义中间变量，需要一堆来判断

	void Awake()
	{
		isNever=false;
		manageCommunicate=GetComponent<ManageCommunicate>();
	}
	void Start () 
	{
		//direct
		manageDirectCommunicate=GetComponent<ManageDirectCommunicate>();

		StartCoroutine("NeverOccurEnemyController");
	}
	
	// Update is called once per frame
	void Update () {
		if(isNever)
		{//isNever注意不要用manageDirectCommunicate.hudCommunicate.isPlayerWin=true代替，违反了direct模式直接传出控制信息。
			StopCoroutine("NeverOccurEnemyController");
			isNever=false;//isNever作为一个触发器
		}
	}
	//控制什么情况下表示永不产生敌人，也包含了一个指向direct
	IEnumerator NeverOccurEnemyController()
	{
		while(true)
		{
			yield return new WaitForSeconds (swapTime);
			if(manageCommunicate.wavesNumberOfBear==0&&manageCommunicate.onceCurrentNumberOfBear==0)
				manageCommunicate.neverOccurBear=true;
			if(manageCommunicate.wavesNumberOfBunny==0&&manageCommunicate.onceCurrentNumberOfBunny==0)
				manageCommunicate.neverOccurBunny=true;
			if(manageCommunicate.wavesNumberOfHellephant==0&&manageCommunicate.onceCurrentNumberOfHellephant==0)
				manageCommunicate.neverOccurHellephant=true;  
			//direct,当manage物体进入了再也不产生敌人的状态而且场景中没有敌人时，给hud联络，告诉他玩家赢了，让hud进入playerWin的状态
			if(manageCommunicate.neverOccurBear&&
			   manageCommunicate.neverOccurBunny&&
			   manageCommunicate.neverOccurHellephant&&
			   GameObject.FindGameObjectsWithTag("Enemy").Length==0)//坑爹，除了Length没其他方法吗，length感觉不正规。
			{

      			manageDirectCommunicate.hudCommunicate.isPlayerWin=true;
				//也表明这时候该协程可以终止
				isNever=true;
			}
		}
	}
}
