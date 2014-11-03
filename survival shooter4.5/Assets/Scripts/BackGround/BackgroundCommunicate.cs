using UnityEngine;
using System.Collections;

public class BackgroundCommunicate : MonoBehaviour 
{

	public float musicVolume;//background属于游戏世界较高的层级，所以基本不会受到其他对象的控制。该参数目前没用。
		//该物体改变自己的状态（音量），是直接读取内存中存储的音量信息。即MenuInfo物体。

}
