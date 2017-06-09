using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public Transform target;

    public float smoothing;


    public float minX;
    public float minY;

    public float maxX;
    public float maxY;


    Vector3 offset;
    float lowV;

	// Use this for initialization
	void Start () {

        float x = PlayerPrefs.GetFloat("CameraPosX", transform.position.x);
        float y = PlayerPrefs.GetFloat("CameraPosY", transform.position.y);
        float z = PlayerPrefs.GetFloat("CameraPosZ", transform.position.z);

        Debug.Log("camX = " + x);
        Debug.Log("camY = " + y);
        Debug.Log("camZ = " + z);

        transform.position = new Vector3(x, y, z);


        offset = transform.position - target.position;

 

        //lowV = transform.position.y;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        Vector3 targetCamPos = target.position + offset;

        if (targetCamPos.x <= minX)
            targetCamPos.x = minX;

        if (targetCamPos.y <= minY)
            targetCamPos.y = minY;

        if (targetCamPos.x >= maxX)
            targetCamPos.x = maxX;

        if (targetCamPos.y >= maxY)
                targetCamPos.y = maxY;


        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

	}



}
