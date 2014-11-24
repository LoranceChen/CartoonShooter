using UnityEngine;
using System.Collections;

public class SycSenceController : MonoBehaviour
{
	LoadingDirectCommunicate ldc;
	void Start()
	{
		ldc=GetComponent<LoadingDirectCommunicate>();
	}
	void Update()
	{//应该用事件监听的方式，而不是循环判断！！！
		if(ldc.bcCom.isPictureShowed)
		{
			Application.LoadLevel("MainSetupNGUI");
		}
	}
}
