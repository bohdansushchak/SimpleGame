using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public Transform target;
    public float smoothing;

    Vector3 offset;
    float lowV;

	// Use this for initialization
	void Start () {
        offset = transform.position - target.position;
        lowV = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);


        if (transform.position.y < lowV)
            transform.position = new Vector3(transform.position.x, lowV, transform.position.z);

	}
}
