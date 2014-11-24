using UnityEngine;
using System.Collections;

public class SliderController : MonoBehaviour 
{
	 public PlayerLifeCommunicate plLifCom;
	 public UISlider plSlider;
	 
	 void Update()
	 {
		// plSlider.value = (float)plLifDirCom.plyCom.currentHealth/plLifDirCom.plyCom.fullHealth;
		plSlider.value=plLifCom.slideValue ;
	}
}
