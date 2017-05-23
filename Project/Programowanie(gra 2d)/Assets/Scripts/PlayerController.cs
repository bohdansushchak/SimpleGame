using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float speed;

    Rigidbody2D body;
    Animator anim;

    bool facingRight;


	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        facingRight = true;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float move = Input.GetAxis("Horizontal");  // може бути -1 або 1 (вправо або вліво)
        anim.SetFloat("speed", Mathf.Abs(move));

        body.velocity = new Vector2(move * speed, body.velocity.y);
        if(move > 0 && !facingRight)
        {
            flip();
        } else if(move < 0 && facingRight)
        {
            flip();
        }
	}

    void flip()
    {
        facingRight = !facingRight;
         Vector3 scale = transform.localScale;
         scale.x *= -1;
         transform.localScale = scale;

       
    }
}
