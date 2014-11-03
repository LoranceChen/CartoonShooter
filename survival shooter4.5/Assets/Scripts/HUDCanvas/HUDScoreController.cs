using UnityEngine;
using System.Collections;

public class HUDScoreController : MonoBehaviour 
{
	public HUDCommunicate hudCom;
	public UILabel scoreLable;
	
	void Update()
	{
		if(hudCom.hasScore)
		{
			scoreLable.text="Score:"+hudCom.score;
			hudCom.hasScore=false;
		}

	}

}
