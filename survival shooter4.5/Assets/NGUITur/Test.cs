using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	public void RedState()
	{
		GetComponent<UISprite>().color=Color.red;
	}
	public void BlueState()
	{
		GetComponent<UISprite>().color=Color.blue;
	}
	public void GreenState()
	{
		GetComponent<UISprite>().color=Color.green;
	}
}
