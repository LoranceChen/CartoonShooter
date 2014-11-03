using UnityEngine;
using System.Collections;

public class MainMenuButtonController : MonoBehaviour {
	public GameObject setupMenuUI;
	public GameObject mainMenuUI;
	public void StartState()
	{
		Application.LoadLevelAsync("MainGameNGUI");
	}
	public void SetUpState()
	{
		setupMenuUI.SetActive(true);
		mainMenuUI.SetActive(false);
	}
	public void Exit()
	{
		MenuSetUpSerialize ms=MenuSetUpSerialize.GetInstance();
		XMLReadAndLoad.Save<MenuSetUpSerialize>(@".\MenuSetUp.xml",ms);
		Application.Quit();
	}
}
