using UnityEngine;
using System.Collections;

public class BackPictureController : MonoBehaviour {
	BackCanvasCommunicate bcCom;
	
	public UISprite bkSprite;
	
	Color tmpC=new Color();
	// Use this for initialization
	void Awake () 
	{
		bcCom=GetComponent<BackCanvasCommunicate>();
		tmpC=bkSprite.color;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!bcCom.isPictureShowed)
		{
			ChangeAlphaState();
			if(bkSprite.color.a>0.9f)
				bcCom.isPictureShowed=true;
		}
	}
	void ChangeAlphaState()
	{
		tmpC.a=Mathf.Lerp(tmpC.a,1f,bcCom.pictureChangeSpeed*Time.deltaTime);
		bkSprite.color=tmpC;
	}
}
