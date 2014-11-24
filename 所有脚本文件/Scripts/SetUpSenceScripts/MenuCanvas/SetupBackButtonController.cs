using UnityEngine;
using System.Collections;

public class SetupBackButtonController : MonoBehaviour {
	public GameObject mainMenuUI;
	public GameObject setupMenuUI;

	public void BackState()
	{
		mainMenuUI.SetActive(true);
		setupMenuUI.SetActive(false);
	}
}
