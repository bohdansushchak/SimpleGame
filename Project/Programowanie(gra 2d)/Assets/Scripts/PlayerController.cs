using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

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
    public Slider equippedAmmo;
    float timeChangeAmmo = 0.2f;
    float nextChangeAmmo = 0;
    public Text textAmmo2;
    public Text textAmmo3;
    public Text textAmmo4;

    //for PlayerMenu
    public GameObject playerMenu;


    //for music
    AudioPlay player;



    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GetComponentInChildren<AudioPlay>();

        float x = PlayerPrefs.GetFloat("PlayerPosX", transform.position.x);
        float y = PlayerPrefs.GetFloat("PlayerPosY", transform.position.y);
        float z = PlayerPrefs.GetFloat("PlayerPosZ", transform.position.z);

        transform.position = new Vector3(x, y, z);

        countProjectile2 = PlayerPrefs.GetInt("bullet2", countProjectile2);
        countProjectile3 = PlayerPrefs.GetInt("bullet3", countProjectile3);
        countProjectile4 = PlayerPrefs.GetInt("bullet4", countProjectile4);

        facingRight = true;
        equippedAmmo.maxValue = 3;
        equippedAmmo.value = 0;

        textAmmo2.text = countProjectile2.ToString();
        textAmmo3.text = countProjectile3.ToString();
        textAmmo4.text = countProjectile4.ToString();


    }

    void Update()
    {
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            anim.SetBool("isGround", true);
            body.AddForce(new Vector2(0, jumpHeight));
            player.Jump();
        }




        if (Input.GetAxis("Fire1") > 0)
            switch (numGun)
            {
                case 0:
                    if(fire(bullet1))
                        player.Shoot_p1();
                    break;
                case 1:
                    if (countProjectile2 != 0 && fire(bullet2))
                    {
                        --countProjectile2;
                        player.Shoot_p2();
                        textAmmo2.text = countProjectile2.ToString();
                    }
                    break;
                case 2:
                    if (countProjectile3 != 0 && fire(bullet3))
                    {
                        --countProjectile3;
                        player.Shoot_p3();
                        textAmmo3.text = countProjectile3.ToString();

                    }
                    break;
                case 3:

                    if (countProjectile4 != 0 && fire(bullet4))
                    {
                        --countProjectile4;
                        player.Shoot_p4();
                        textAmmo4.text = countProjectile4.ToString();

                    }

                    break;
            }

        if (Input.GetAxis("Fire3") > 0)
        {
            changeAmmo();
        }


            if (Input.GetKeyDown("escape"))
            {

            if (Time.timeScale == 1.0)
            {
                playerMenu.SetActive(true);
                Time.timeScale = 0.00001f;
            }
            else
            {
                Time.timeScale = 1.0f;
                playerMenu.SetActive(false);
            }
                
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

       // if (move != 0)
           // player.Walk();
	}

    void flip() {

        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;


        //Player.transform.Rotate(new Vector3(0, 180, 0));
       /* if (Player.transform.rotation.y >= 180)
            Player.transform.Rotate(new Vector3(0, 0, 0));
        else
            Player.transform.Rotate(new Vector3(0, 180, 0));*/

    }

    void changeAmmo()
    {
        if(Time.time > nextChangeAmmo)
        {
            nextChangeAmmo = Time.time + timeChangeAmmo;

            if (numGun < 3)
                ++numGun;
            else
                numGun = 0;

            equippedAmmo.value = numGun;
        }

    }

    bool fire(GameObject bullet) {
        if (Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;
            if (facingRight)
                //Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            NetworkManager.Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));

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
                textAmmo2.text = countProjectile2.ToString();
                break;
            case 3:
                countProjectile3 += count;
                textAmmo3.text = countProjectile3.ToString();
                break;
            case 4:
                countProjectile4 += count;
                textAmmo4.text = countProjectile4.ToString();
                break;
        }
        
    }

    public int Bullet2
    {
        get { return countProjectile2; }
    }

    public int Bullet3
    {
        get { return countProjectile3; }
    }

    public int Bullet4
    {
        get { return countProjectile4; }
    }


}
