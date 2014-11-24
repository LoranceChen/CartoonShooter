using UnityEngine;
using System.Collections;

public class InputDirectCommunicate : MonoBehaviour {
	public PlayerCommunicate playerCommunicate;
	public InputCommunicate inputCom;
	//除了在Awake中指定要交流的外界对象外，还可以public方式在inspector中初始化
	void Awake()
	{
		//playerCommunicate=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCommunicate>();
		//print (playerCommunicate);
		StartCoroutine("FindPlayer");//player为动态创建，所以关联player是重要的一个任务
	}
	IEnumerator FindPlayer()
	{
		bool isFindPalyer=false;
		while(!isFindPalyer)
		{
			yield return new WaitForSeconds(1f);
			if((playerCommunicate=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCommunicate>())!=null)
			{
				inputCom.findPlayer=true;
				isFindPalyer=true;
			}
		}
	}
}
