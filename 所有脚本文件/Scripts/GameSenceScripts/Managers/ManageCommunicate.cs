using UnityEngine;
using System.Collections;
//敌人的生成是动态的当前的人数，波数等可以受外部影响。有时是敌人数量，波数。都能直接影响控制器

public class ManageCommunicate : MonoBehaviour{
	//如果按照本意不应该设定这么多的区别，并不对3种敌人有歧视，从产生来讲3中都一样。所以除了GameObject之外，其他变量都是一个
	//位置
	public Transform bearTransfrom;
	public Transform bunnyTransfrom;
	public Transform hellephantTransfrom;
	//敌人gamobject
	public GameObject bear;
	public GameObject bunny;
	public GameObject hellephant;

	//一波敌人中每个敌人产生的时间间隔，单位是秒
	public float onceTimeBear=1.5f;
	public float onceTimeBunny=2f;
	public float onceTimeHellephant=4f;
	//一波中敌人的个数
	public int onceNumberOfBear=5;
	public int onceNumberOfBunny=5;
	public int onceNumberOfHellephant=5;
	//当前波中敌人的个数，临时值，比如吃了道具，这一波的敌人不在产生，敌人直接按下一波产生
	public int onceCurrentNumberOfBear=5;
	public int onceCurrentNumberOfBunny=5;
	public int onceCurrentNumberOfHellephant=5;

	//每波的时间间隔,单位是秒
	public float wavesTimeBear=10;
	public float wavesTimeBunny=15;
	public float wavesTimeHellephant=30;
	//敌人的波数,这里不需要和onceNumber一样设定当前波，因为它也就表示当前波
		//而onceNumber不同，需要两个变量
	public int wavesNumberOfBear=2;
	public int wavesNumberOfBunny=2;
	public int wavesNumberOfHellephant=1;
	//直接参数状态，开始产生和停止产生敌人
	public bool allowOccurBear=true;
	public bool allowOccurBunny=true;
	public bool allowOccurHellephant=true;
	//直接状态参数，再也不会有产生敌人
	public bool neverOccurBear=false;
	public bool neverOccurBunny=false;
	public bool neverOccurHellephant=false;
	IEnumerator GetEnumerator()
	{
		return (IEnumerator) GetEnumerator();
	}
}