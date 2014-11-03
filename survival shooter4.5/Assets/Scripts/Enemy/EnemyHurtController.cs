using UnityEngine;
using System.Collections;

public class EnemyHurtController : MonoBehaviour {
	AudioSource hurtAudio;
	ParticleSystem hurtParticle;
	EnemyCommunicate enemyCommunicate;

	void Awake () {
		enemyCommunicate=GetComponent<EnemyCommunicate>();
		hurtAudio=GetComponent<AudioSource>();
		hurtParticle=GetComponentInChildren<ParticleSystem>();
	}

	void Update () {
		//发现是受伤状态，就减血
		if(enemyCommunicate.isHurt)//&&enemyCommunicate.currentHealth-enemyCommunicate.hurtDamageValue>0)
		{
			enemyCommunicate.currentHealth-=enemyCommunicate.hurtDamageValue;
			if(enemyCommunicate.currentHealth>0)
			{
				HurtState();
				enemyCommunicate.isHurt=false;
			}
		}
	}
	//受伤状态,减血操作在控制中写，状态层不与交互层交互，交互层与外界，控制层交互。
	void HurtState()
	{
		hurtAudio.Play();
		hurtParticle.transform.position=enemyCommunicate.hurtPosition;
		hurtParticle.Play();
	}
}
