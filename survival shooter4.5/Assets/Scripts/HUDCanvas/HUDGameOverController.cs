using UnityEngine;
using System.Collections;

public class HUDGameOverController : MonoBehaviour {
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
		if(hudCommunicate.isGameOver)
		{
			GameOverState();
			hudDirectCommunicate.inputCommunicate.needComToPlayer=false;
			hudCommunicate.isGameOver=false;
		}
	}
	void GameOverState()
	{
		anim.SetTrigger("GameOver");
	}
}
