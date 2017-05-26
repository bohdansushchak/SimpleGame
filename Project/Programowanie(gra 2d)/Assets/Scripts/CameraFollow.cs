using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public Transform target;
    public float smoothing;


    public float minX;
    public float minY;
    //public float minZ;

    public float maxX;
    public float maxY;
   // public float maxZ;

    Vector3 max;
    Vector3 min;

    Vector3 offset;
    float lowV;

	// Use this for initialization
	void Start () {

        min = new Vector3(minX, minY, 0);
        max = new Vector3(maxX, maxY, 0);
        
        offset = transform.position - target.position;
        lowV = transform.position.y;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        Vector3 targetCamPos = target.position + offset;
        if (asd(targetCamPos)){

            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);


            if (transform.position.y < lowV)
                transform.position = new Vector3(transform.position.x, lowV, transform.position.z);
        }

	}


    bool asd(Vector3 pos)
    {
        if ((minX <= pos.x && pos.x <= maxX) || (minY <= pos.y && pos.y <= maxY))
            return true;
        else return false;
    }  
}
