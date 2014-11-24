using UnityEngine;
using System.Collections;

public class _CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothing;
    
	PlayerCommunicate playerCommunicate;
	bool isFindPalyer;
    Vector3  off;
    Vector3 targetCamPos;
   	
    void Start() {
        
		StartCoroutine("CamFindPlayer");
    }
	IEnumerator CamFindPlayer()
	{
		while(!isFindPalyer)
		{
			yield return new WaitForSeconds(1f);
			if((playerCommunicate=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCommunicate>())!=null)
			{
				target=playerCommunicate.transform;
				off =transform.position-target.position;

				isFindPalyer=true;
			}
		}
	}
    void LateUpdate() { 
        //求出相机的目标位置
		if(isFindPalyer)
		{
	        targetCamPos = target.position + off;
	        //插值更新相机位置
	        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
		}
	}
}
