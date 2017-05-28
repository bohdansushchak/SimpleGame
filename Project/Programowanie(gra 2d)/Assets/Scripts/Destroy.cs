using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {


     public float timeAlive;
	// Use this for initialization
	void Awake () {
        Destroy(gameObject, timeAlive);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
