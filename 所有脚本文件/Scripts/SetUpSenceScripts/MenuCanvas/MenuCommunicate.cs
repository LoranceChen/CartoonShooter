using UnityEngine;
using System.Collections;

public class MenuCommunicate : MonoBehaviour 
{
//交互层参数的控制函数，受外界输入影响
    public bool isStart;
	public bool isSetup;
	public bool isExit;

    public void IsStart() 
    {
        isStart = true;  
    }
    public void IsSetup()
    {
        isSetup = true;
    }
    public void IsExit ()
    {
        isExit = true;
    }
}
