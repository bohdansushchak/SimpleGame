using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {


    public float walkSpeed;
    public float runSpeed;
    public GameObject dropItem;

    Animator anim;
    Rigidbody2D enemyBody;
    EnemyHealth health;

    bool facingRight = true;

    float nextFlipChance;
    float flipTime = 2;

    bool walking;
    bool run;
    bool attack;

    bool barrier;

    bool grounded = false;
    float groundCheckValue = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;



    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyBody = GetComponent<Rigidbody2D>();
        health = GetComponent<EnemyHealth>();

        nextFlipChance = 0;

        walking = false;
        run = false;
        attack = false;
        grounded = false;

    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckValue, groundLayer);

        if (barrier || !grounded)
                flip();

        if (attack)
        {
            walking = false;
            run = false;
        }
        else
        {
            walking = true;
            run = false;
        }


            if (Time.time > nextFlipChance && !attack)
            {
                nextFlipChance = Time.time + flipTime;

                if (Random.Range(0, 10) >= 7)
                    walking = false;
                else
                    walking = true;
            }
        if (walking)
        {
            if (health.HalfHeath)
                run = true;
            else run = false;
        }

        if (run)
        {
            Animator("run", run);
            Move(runSpeed);
        }
        else if (walking)
        {
            Move(walkSpeed);
            Animator("run", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") { 
            attack = false;
            Animator("isHit", attack);
        }

        if (collision.tag == "Enemy")
            barrier = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player") {
            attack = true;
            Animator("isHit", attack);
            Animator("run", false);

        }

        if (collision.tag == "Enemy")
            barrier = true;

    }


   void Move(float speed)
   {
       if (facingRight)
           enemyBody.velocity = new Vector2(1 * speed, enemyBody.velocity.y);
       else
           enemyBody.velocity = new Vector2(-1 * speed, enemyBody.velocity.y);

        Animator("run", true);
   }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void Animator(string var, bool value)
    {
        if (anim == null)
            Destroy(gameObject);
        anim.SetBool(var, value);
    }
}
   