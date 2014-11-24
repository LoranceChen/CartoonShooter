using UnityEngine;
using System.Collections;

public class SetupMusicController : MonoBehaviour {
	public UISlider bkmSlider;
	public UISlider efvSlider;

	bool firstBmChange;
	bool firstEfcChange;
	void Awake()
	{
		MenuSetUpSerialize ms=MenuSetUpSerialize.GetInstance();
		bkmSlider.value=ms.backMusicVolume;
		efvSlider.value=ms.efSoundVolume;
	}
	// Use this for initialization
	public void BackMusicState(){
		MenuSetUpSerialize ms= MenuSetUpSerialize.GetInstance();
		ms.backMusicVolume= bkmSlider.value;
		//print (ms.backMusicVolume);
	}
	public void EffectVolumeState()
	{
		MenuSetUpSerialize ms=MenuSetUpSerialize.GetInstance();
		ms.efSoundVolume=efvSlider.value;
		//print (ms.efSoundVolume);
	}
}
