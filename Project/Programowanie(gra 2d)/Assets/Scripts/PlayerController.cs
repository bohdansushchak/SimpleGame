using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //for run
    public float speed;
    Rigidbody2D body;
    Animator anim;
    bool facingRight;

    //for jump
    bool grounded = false;
    float groundCheckValue = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;


    //for shooting
    public Transform gunTip;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;

    public int countProjectile2;
    public int countProjectile3;
    public int countProjectile4;
    float fireRate = 0.5f;
    float nextFire = 0.0f;
    int numGun = 0;



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


        if (Input.GetAxis("Fire1") > 0)
            switch(numGun)
            {
                case 0:
                    fire(bullet1);
                    break;
                case 1:
                    if (countProjectile2 != 0 && fire(bullet2))
                        --countProjectile2;                 
                    break;
                case 2:
                    if (countProjectile3 != 0 && fire(bullet3))
                        --countProjectile3;
                    break;
                case 3:

                    if (countProjectile4 != 0 && fire(bullet4))
                        --countProjectile4;
                    break;
            }

        if (Input.GetAxis("Fire3") > 0)
        {
            if (numGun < 3)
                ++numGun;
            else
                numGun = 0;
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

    void flip() {

        facingRight = !facingRight;
         Vector3 scale = transform.localScale;
         scale.x *= -1;
         transform.localScale = scale;

       
    }

    bool fire(GameObject bullet) {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));

            else
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));

            return true;

        }
        else return false; 
    }

    public void addAmmo(int count, int id)
    {
        switch (id)
        {
            case 2:
                countProjectile2 += count;
                break;
            case 3:
                countProjectile3 += count;
                break;
            case 4:
                countProjectile4 += count;
                break;
        }
        
    }

}
