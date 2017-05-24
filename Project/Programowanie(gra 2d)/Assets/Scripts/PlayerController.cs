using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float speed;

    Rigidbody2D body;
    Animator anim;

    bool facingRight;


    bool grounded = false;
    float groundCheckValue = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;



	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        facingRight = true;

	}

    void Update(){
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            anim.SetBool("isGround", true);
            body.AddForce(new Vector2(0, jumpHeight));
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {



        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckValue, groundLayer);
        anim.SetBool("isGround", grounded);
        anim.SetFloat("verticalSpeed", body.velocity.y);

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
