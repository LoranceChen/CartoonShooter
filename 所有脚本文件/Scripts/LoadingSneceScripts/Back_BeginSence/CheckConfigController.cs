using UnityEngine;
using System.Collections;
using System.IO;

public class CheckConfigController: MonoBehaviour {

	// Use this for initialization
	void Start () {
		try
		{
			//load info
			MenuSetUpSerialize ms=XMLReadAndLoad.Load<MenuSetUpSerialize>(@".\MenuSetUp.xml");
			MenuSetUpSerialize instnce=MenuSetUpSerialize.GetInstance();
			instnce.CopyValue(ms);
		}
		catch(FileNotFoundException)
		{
			//创建一个新的xml,并创建单例
			MenuSetUpSerialize instnce=MenuSetUpSerialize.GetInstance();
			XMLReadAndLoad.Save<MenuSetUpSerialize>(@".\MenuSetUp.xml",instnce);
		}
	}
}
