using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControler : MonoBehaviour {


    public float speed;

    Rigidbody2D body;

	// Use this for initialization
	void Awake () {
        body = GetComponent<Rigidbody2D>();

        if(transform.localRotation.z > 0)
            body.AddForce(new Vector2(-1, 0) * speed, ForceMode2D.Impulse);
        else
            body.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Impulse);
    }
	
    public void removeForce()
    {
        body.velocity = new Vector2(0, 0);
    }
}
