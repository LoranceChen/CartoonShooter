using UnityEngine;
using System.Collections;

public class SetUpDirectCommunicate : MonoBehaviour {
	//public MenuSetUpInfo menuSetUpInfo;//需要菜单相关信息，现在不将这种纯粹的信息作为一个GameObject，而将它看作data信息

	public MenuCommunicate menuCommunicate;//只能在inspector中手动引用。
	void Awake()
	{
		//menuCommunicate=GameObject.FindGameObjectWithTag("MenuCanvas").GetComponent<MenuCommunicate>();
		if(menuCommunicate==null)
			print ("false");
		//menuSetUpInfo=GameObject.FindGameObjectWithTag("MenuSetUp").GetComponent<MenuSetUpInfo>();
	}
}
