using UnityEngine;
using System.Collections;

public class BackgroundMusicController : MonoBehaviour 
{
	//BackgroundCommunicate bgComucate;
	//BackgroundDirectCommunicate bgDirCommucate;
	public AudioSource bgSource;
	void Awake()
	{
		//bgComucate=GetComponent<BackgroundCommunicate>();
		//bgDirCommucate=GetComponent<BackgroundDirectCommunicate>();
	}
	void Start()
	{
		BackgroundMusicState(MenuSetUpSerialize.GetInstance().backMusicVolume);
	}
	void BackgroundMusicState(float v)
	{
		bgSource.volume=v;
	}
}
