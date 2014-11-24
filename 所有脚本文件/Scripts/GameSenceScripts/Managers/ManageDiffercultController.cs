using UnityEngine;
using System.Collections;

public class ManageDiffercultController : MonoBehaviour {
//	ManageDirectCommunicate manageDirCommuncate;
	ManageCommunicate manageCommunicate;
	bool needComm;//控制自己的行为
	void Awake()
	{
		manageCommunicate=GetComponent<ManageCommunicate>();
	}
	void Start()
	{
	//	manageDirCommuncate=GetComponent<ManageDirectCommunicate>();
		needComm=true;
	}

	void Update() 
	{
		//关闭难度调节
		if(needComm)
		{
			//onceTimeBear,onceNumberOfBear,onceCurrentNumberOfBear,wavesTimeBear,wavesNumberOfBear
			//2,2,4     3,4,2       555     5,7,10    111
			switch(MenuSetUpSerialize.GetInstance().difficultyLevel)
			{
				case 1:
					EasyState();
					break;
				case 2:
					MiddleState();
					break;
				case 3:
					DifState();
					break;
			}
			needComm=false;
		}
		//打开难度调节
	}

	void EasyState()
	{
	
	

		manageCommunicate.onceNumberOfBear=3;
		manageCommunicate.onceNumberOfBunny=4;
		manageCommunicate.onceNumberOfHellephant=2;

		manageCommunicate.onceCurrentNumberOfBear=5;
		manageCommunicate.onceCurrentNumberOfBunny=5;
		manageCommunicate.onceCurrentNumberOfHellephant=5;

		manageCommunicate.wavesTimeBear=5;
		manageCommunicate.wavesTimeBunny=7;
		manageCommunicate.wavesTimeHellephant=10;

		manageCommunicate.wavesNumberOfBear=1;
		manageCommunicate.wavesNumberOfBunny=1;
		manageCommunicate.wavesNumberOfHellephant=1;
	}
	void MiddleState()
	{
	
		
		manageCommunicate.onceNumberOfBear=4;
		manageCommunicate.onceNumberOfBunny=5;
		manageCommunicate.onceNumberOfHellephant=3;
		
		manageCommunicate.onceCurrentNumberOfBear=6;
		manageCommunicate.onceCurrentNumberOfBunny=6;
		manageCommunicate.onceCurrentNumberOfHellephant=6;
		
		manageCommunicate.wavesTimeBear=4;
		manageCommunicate.wavesTimeBunny=6;
		manageCommunicate.wavesTimeHellephant=9;
		
		manageCommunicate.wavesNumberOfBear=1;
		manageCommunicate.wavesNumberOfBunny=1;
		manageCommunicate.wavesNumberOfHellephant=1;
	}
	void DifState()
	{

		
		manageCommunicate.onceNumberOfBear=4;
		manageCommunicate.onceNumberOfBunny=5;
		manageCommunicate.onceNumberOfHellephant=3;
		
		manageCommunicate.onceCurrentNumberOfBear=6;
		manageCommunicate.onceCurrentNumberOfBunny=6;
		manageCommunicate.onceCurrentNumberOfHellephant=6;
		
		manageCommunicate.wavesTimeBear=4;
		manageCommunicate.wavesTimeBunny=6;
		manageCommunicate.wavesTimeHellephant=9;
		
		manageCommunicate.wavesNumberOfBear=2;
		manageCommunicate.wavesNumberOfBunny=2;
		manageCommunicate.wavesNumberOfHellephant=2;
	}
}
