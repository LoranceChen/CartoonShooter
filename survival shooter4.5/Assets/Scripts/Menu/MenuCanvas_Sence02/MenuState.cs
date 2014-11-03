using UnityEngine;
using System.Collections;

public class MenuState : MonoBehaviour {
    //三个状态，start状态，setup状态，exit状态
    public GameObject setupCanvas;//从状态层引用会失败！

    public void StartState(bool isStart)//状态调节参数在括号里传入 
    {
        Application.LoadLevel("MyGame");

    }
    public void SetupState(bool isSetUp) 
    {
		//切换两个Canvas的可见度
        setupCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
    public void ExitState(bool isExit) {
        Application.Quit();

    }
}
