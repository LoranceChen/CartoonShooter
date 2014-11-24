using UnityEngine;
using System.Collections;

public class HUDWinController : MonoBehaviour {
	HUDCommunicate hudCommunicate;
	HUDDirectCommunicate hudDirectCommunicate;

	Animator anim;
	void Awake()
	{
		hudCommunicate=GetComponent<HUDCommunicate>();
		anim=GetComponent<Animator>();


	}
	void Start()
	{
		hudDirectCommunicate=GetComponent<HUDDirectCommunicate>();

	}
	void Update()
	{
		if(hudCommunicate.isPlayerWin)
		{
			PlayerWinState();
			hudDirectCommunicate.inputCommunicate.needComToPlayer=false;
			hudCommunicate.isPlayerWin=false;
		}
	}
	void PlayerWinState()
	{
		//触发一次
		anim.SetTrigger("PlayerWin1");
	}
}