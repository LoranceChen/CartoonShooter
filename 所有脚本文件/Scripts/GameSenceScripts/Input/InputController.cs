using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
    InputCommunicate inputCommunicate;
	InputDirectCommunicate inputDirectCommunicate;
    //中间变量
    Ray ray;
	float camRayLength=100f;
	Vector3 playerPosition;

	void Awake () {
	    inputCommunicate=GetComponent<InputCommunicate>();
		inputDirectCommunicate=GetComponent<InputDirectCommunicate>();
   		//对交互层赋初值，因为mask函数必须在主线程下进行
	}
	void Start()
	{
		//player的位置是实时获取的，不能省字数！！！！
		//playerPosition=inputDirectCommunicate.playerCommunicate.transform.position;
	}
	// Update is called once per frame
	void Update () {
        //控制键盘
		if(inputCommunicate.findPlayer)//没找到player不进行任何处理
		{
			if(inputCommunicate.needComToPlayer)
			{
				//print("inputCommunicate.needComToPlaye:"+inputCommunicate.needComToPlayer);
		        inputDirectCommunicate.playerCommunicate.hInput = Input.GetAxisRaw("Horizontal");
				inputDirectCommunicate.playerCommunicate.vInput = Input.GetAxisRaw("Vertical");

		        //控制鼠标的位置信息，传递给player  
		        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		        	
				RaycastHit floorHit;//鼠标在3d中发射的射线，找到它和地板的交点

				if (Physics.Raycast(camRay, out floorHit, camRayLength,LayerMask.GetMask(inputCommunicate.floorMask)))
		        {
		            //通过射线碰撞的信息确定该点位置,
					//！！！！这里曾经出现了2个小时的bug，误用 inputCommunicate.transform.position。坑爹，无论如何总体纵向不容易控制。
						//添加中间变量方便管理,但不能实时响应Communicate的变化。所以...
					inputDirectCommunicate.playerCommunicate.playerToMouse = floorHit.point - inputDirectCommunicate.playerCommunicate.transform.position;
					inputDirectCommunicate.playerCommunicate.playerToMouse.y = 0f; 

		        }
				//控制鼠标，player的开火.注意开关都要控制

				if(Input.GetButton("Fire1"))
				{
					inputDirectCommunicate.playerCommunicate.isFire=true;
					//print ("Fire");
				}else 
					inputDirectCommunicate.playerCommunicate.isFire=false;
			}
			else //如果不允许用户接受输入，应该把用户的isFire设定为false
			{
				//关闭输入
				inputDirectCommunicate.playerCommunicate.hInput = 0f;
				inputDirectCommunicate.playerCommunicate.vInput = 0f ;
				inputDirectCommunicate.playerCommunicate.isFire=false;
				//inputDirectCommunicate.playerCommunicate.playerToMouse=
			}
		}
	}
}
