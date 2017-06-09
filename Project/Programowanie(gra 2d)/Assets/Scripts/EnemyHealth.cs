using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float MaxHealth;
    public GameObject deadEffect;
    public GameObject dropItem;

    Animator anim;

    float currentHealth;

    bool halfHealth;


	// Use this for initialization
	void Start () {
        currentHealth = MaxHealth;
        //isDead = false;
        halfHealth = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= MaxHealth / 2)
            halfHealth = true;

        if(currentHealth <= 0)
        {
            dead();
            //isDead = true;
            
        }
    }

  /* public bool Dead
    {
        get { return isDead; }
    }*/

    void dead()
    {
        

        if (deadEffect != null)
            Instantiate(deadEffect, transform.position, transform.rotation);

        if(dropItem != null)
        {
            Instantiate(dropItem, transform.position, transform.rotation);

        }

        if (anim != null)
            anim.SetBool("dead", true);

        Destroy(gameObject);

    }

   public bool HalfHeath{
        get { return halfHealth; }
    }


}
