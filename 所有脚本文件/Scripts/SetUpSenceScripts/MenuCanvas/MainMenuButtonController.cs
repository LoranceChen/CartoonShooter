using UnityEngine;
using System.Collections;

public class MainMenuButtonController : MonoBehaviour {
	public GameObject setupMenuUI;
	public GameObject mainMenuUI;
	public GameObject netMenuUI;
	public void StartState()
	{
		Application.LoadLevelAsync("MainGameNGUI");
	}
	public void SetUpState()
	{
		setupMenuUI.SetActive(true);
		mainMenuUI.SetActive(false);
	}
	public void ExitState()
	{
		MenuSetUpSerialize ms=MenuSetUpSerialize.GetInstance();
		XMLReadAndLoad.Save<MenuSetUpSerialize>(@".\MenuSetUp.xml",ms);
		Application.Quit();
	}
	public void NetState()
	{
		netMenuUI.SetActive(true);
		mainMenuUI.SetActive(false);
	}
}
