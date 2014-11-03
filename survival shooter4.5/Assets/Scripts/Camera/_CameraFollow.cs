using UnityEngine;
using System.Collections;

public class _CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothing;
    
    Vector3  off;
    Vector3 targetCamPos;
   
    void Start() {
        off =transform.position-target.position;
    }

    void LateUpdate() { 
        //求出相机的目标位置
        targetCamPos = target.position + off;
        //插值更新相机位置
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
