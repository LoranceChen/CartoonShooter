using UnityEngine;
using System.Collections;
//交互层影响该控制/状态的属性1.neverOccur系列,2.allowOccur系列...貌似全都是


public class ManageOccurQuitEnemyController : MonoBehaviour {
	//控制协同函数的终止只能在同一个类中。所以Occur和Quit本是两个状态，无奈之下只能写在一个控制器中。
	ManageCommunicate manageCommunicate;

	//敌人从产生到不产生，或者不产生到产生的休息间隔
	//这里也是控制变量，专属于控制层.是为了优化而设计的变量，没有在环境中改变的理由
	 float changeStateIntervalOfBear=1f;//从产生和不产生的变化的执行的间隔
	 float changeStateIntervalOfBunny=1f;
	 float changeStateIntervalOfHellephant=1f;

	void Awake()
	{
		manageCommunicate=GetComponent<ManageCommunicate>();
	}
	void Start()
	{


		StartCoroutine("BearOccurController");//可用函数形式,但是和stopcoroutine不能匹配
															//而stop必须用string才能起作用，所以这里也只能用string以和他匹配
															//其实更倾向函数形式，毕竟能检查错别字。不能匹配是bug！！！！
		StartCoroutine("BunnyOccurController");
		StartCoroutine("HellephantOccurController");
	}


	void Update () {
		if(manageCommunicate.neverOccurBear)
			StopCoroutine("BearOccurController");//停止协同函数,这里不能用函数形式，只能用string才起作用
		if(manageCommunicate.neverOccurBunny)
			StopCoroutine("BunnyOccurController");
		if(manageCommunicate.neverOccurHellephant)
			StopCoroutine("HellephantOccurController");
	}
	//控制敌人产生，描述敌人是以什么样的形式产生的。
		//针对所有敌人
	IEnumerator BearOccurController()
	{	
		while(true)
		{
			//一直循环太占用内存，休息一下
			yield return new WaitForSeconds (changeStateIntervalOfBear);

			if(manageCommunicate.allowOccurBear)//标志允许产生
			{
				for(;manageCommunicate.wavesNumberOfBear>0;manageCommunicate.wavesNumberOfBear--)//波数表示还有几次循环。
				{
					manageCommunicate.onceCurrentNumberOfBear=manageCommunicate.onceNumberOfBear;//新的一波重新赋值
					//print ("manageCommunicate.wavesNumberOfBear:"+manageCommunicate.wavesNumberOfBear);
					for(;manageCommunicate.onceCurrentNumberOfBear>0;manageCommunicate.onceCurrentNumberOfBear--)//这一波敌人的剩余量
					{
						BearOccurState(manageCommunicate.bear,manageCommunicate.bearTransfrom.position,manageCommunicate.bearTransfrom.rotation);
						if(!manageCommunicate.allowOccurBear)//随时注意是否允许产生敌人
							break;
						//onceTimeBear
						yield return new WaitForSeconds (manageCommunicate.onceTimeBear);//一波中每个敌人的间隔
					}
					if(!manageCommunicate.allowOccurBear)//随时注意是否允许产生敌人
						break;
					yield return new WaitForSeconds (manageCommunicate.wavesTimeBear);
				}
			}
		}
	}
	IEnumerator BunnyOccurController()
	{
		while(true)
		{
			//一直循环太占用内存，休息一下
			yield return new WaitForSeconds (changeStateIntervalOfBunny);

			if(manageCommunicate.allowOccurBunny)//标志允许产生
			{
				for(;manageCommunicate.wavesNumberOfBunny>0;manageCommunicate.wavesNumberOfBunny--)//产生几波
				{
					manageCommunicate.onceCurrentNumberOfBunny=manageCommunicate.onceNumberOfBunny;
					for(;manageCommunicate.onceCurrentNumberOfBunny>0;manageCommunicate.onceCurrentNumberOfBunny--)//一波的敌人数量
					{
						BunnyOccurState(manageCommunicate.bunny,manageCommunicate.bunnyTransfrom.position,manageCommunicate.bunnyTransfrom.rotation);
						if(!manageCommunicate.allowOccurBunny)//随时注意是否允许产生敌人
							break;
						//onceTimeBunny
						yield return new WaitForSeconds (manageCommunicate.onceTimeBunny);//一波中每个敌人的间隔
					}
					if(!manageCommunicate.allowOccurBunny)//随时注意是否允许产生敌人
						break;
					yield return new WaitForSeconds (manageCommunicate.wavesTimeBunny);
				}
			}

		}
	}
	IEnumerator HellephantOccurController()
	{
		while(true)
		{
			//一直循环太占用内存，休息一下
			yield return new WaitForSeconds (changeStateIntervalOfHellephant);
			//控制
			if(manageCommunicate.allowOccurHellephant)//标志允许产生
			{
				for(;manageCommunicate.wavesNumberOfHellephant>0;manageCommunicate.wavesNumberOfHellephant--)//产生几波
				{
					manageCommunicate.onceCurrentNumberOfHellephant=manageCommunicate.onceNumberOfHellephant;
					for(;manageCommunicate.onceCurrentNumberOfHellephant>0;manageCommunicate.onceCurrentNumberOfHellephant--)//一波的敌人数量
					{
						HellephantOccurState(manageCommunicate.hellephant,manageCommunicate.hellephantTransfrom.position,manageCommunicate.hellephantTransfrom.rotation);
						if(!manageCommunicate.allowOccurHellephant)//随时注意是否允许产生敌人
							break;
						//onceTimeHellephant
						yield return new WaitForSeconds (manageCommunicate.onceTimeHellephant);//一波中每个敌人的间隔
					}
					if(!manageCommunicate.allowOccurHellephant)//随时注意是否允许产生敌人
						break;
					yield return new WaitForSeconds (manageCommunicate.wavesTimeHellephant);
				}
			}

		}
	}
	//每种产生敌人的状态
	void BearOccurState(  GameObject bear,
	                    			Vector3 position,
	                    			Quaternion rotation)
	{//描述如何产生一个物体
		//针对一个敌人
		//一个敌人的产生时的状态描述，当旋转，位置都是状态参数。
		//注意状态不要与交换层进行数据传输
		Instantiate(bear,position,rotation);
	}
	void BunnyOccurState(GameObject bunny,
	                    Vector3 position,
	                    Quaternion rotation)
	{
		Instantiate(bunny,position,rotation);
	}
	void HellephantOccurState(  GameObject hellephant,
	                     Vector3 position,
	                     Quaternion rotation)
	{
		Instantiate(hellephant,position,rotation);
	}
}
