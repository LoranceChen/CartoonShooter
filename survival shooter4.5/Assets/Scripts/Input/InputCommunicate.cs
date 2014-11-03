using UnityEngine;
using System.Collections;

public class InputCommunicate : MonoBehaviour 
{
    //交换层传出信息，传出交换层
		//与player的交流
	public bool needComToPlayer;
	public string floorMask;//控制鼠标点击让人物移动的层，针对player的射击
		//当改变这个值时，player会看向不同的物体
	public void NeedComToPlayer()
	{
		needComToPlayer= true;
	}
}
