using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {


    public float walkSpeed;
    public float runSpeed;

    Animator anim;
    Rigidbody2D enemyBody;
    EnemyHealth health;

    bool facingRight = true;

    float nextFlipChance;
    float flipTime = 2;

    bool walking;
    //bool run;
    bool attack;

    bool barrier;

    bool grounded = false;
    float groundCheckValue = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    float time = 0;



    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyBody = GetComponent<Rigidbody2D>();
        health = GetComponent<EnemyHealth>();

        nextFlipChance = 0;

        walking = false;
        //run = false;
        attack = false;
        grounded = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (attack)
        {
            walking = false;
        //    anim.SetBool("hit", attack);
         //   anim.SetBool("run", walking);

        }
        else
        {
            walking = true;


            grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckValue, groundLayer);


            if ((barrier || !grounded) && (Time.time > time))
            {
                flip();
                time = Time.time + Random.Range(0.1f, 0.4f);

            }

            if (Time.time > nextFlipChance && !attack)
            {
                nextFlipChance = Time.time + flipTime;

                if (Random.Range(0, 10) >= 7)
                    walking = false;
                else
                    walking = true;
            }

            if (walking && !barrier)
            {
                if (health.HalfHeath)
                    Move(runSpeed);
                else Move(walkSpeed);
            }

           


            /*      if (run)
                  {
                      //Animator("run", run);
                      Move(runSpeed);
                  }
                  else if (walking)
                  {
                      Move(walkSpeed);
                      //Animator("run", false);
                  }*/
        }
        anim.SetBool("run", walking);
        anim.SetBool("hit", attack);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") { 
            attack = false;
            //Animator("isHit", false);
        } else if (collision.tag == "Enemy")
            barrier = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player") {
            attack = true;
           // Animator("isHit", attack);
           // Animator("run", false);

        }
        else if (collision.tag == "Enemy")
            barrier = true;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            attack = true;
            //Animator("isHit", attack);
            //Animator("run", false);

        }
        else if (collision.tag == "Enemy")
            barrier = true;

    }


    void Move(float speed)
   {
       if (facingRight)
           enemyBody.velocity = new Vector2(1 * speed, enemyBody.velocity.y);
       else
           enemyBody.velocity = new Vector2(-1 * speed, enemyBody.velocity.y);

       // Animator("run", true);
   }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

   /* void Animator(string var, bool value)
    {
        if (anim != null)
            //Destroy(gameObject);
        anim.SetBool(var, value);
    }*/
}
   