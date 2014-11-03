using UnityEngine;
using System.Collections;

public class SliderController : MonoBehaviour 
{
	 public PlayerLifeDirectCommunicate plLifDirCom;
	 public UISlider plSlider;
	 
	 void Update()
	 {
		 plSlider.value = (float)plLifDirCom.plyCom.currentHealth/plLifDirCom.plyCom.fullHealth;
	 }
}
