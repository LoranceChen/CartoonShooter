using UnityEngine;
using System.Collections;

public class PlayerShootSoundVolumeController : MonoBehaviour {
	public AudioSource efsAudio;
	// Use this for initialization
	void Start () 
	{
		ShootSoundVolume(MenuSetUpSerialize.GetInstance().efSoundVolume);
	}
	void ShootSoundVolume(float volume)
	{
		efsAudio.volume=volume;
	}
}
