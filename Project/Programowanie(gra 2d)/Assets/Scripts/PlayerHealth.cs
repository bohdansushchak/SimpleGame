using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {


    //public int LifeScore;
    public float FullHealth;
    public GameObject blood;

    float currentHealth;

    PlayerController controlMovement;
    public Slider healthSlider;

	// Use this for initialization
	void Start () {
        currentHealth = FullHealth;
        controlMovement = GetComponent<PlayerController>();

        healthSlider.maxValue = FullHealth;
        healthSlider.value = FullHealth;

        //hearthImage.
 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage)
    {
        if (damage <= 0) return;

        currentHealth -= damage;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
            dead();
    } 

    public void dead()
    {
        Instantiate(blood, transform.position, transform.rotation);
        gameObject.SetActive(false);
        //--LifeScore;

      /*  if(LifeScore > 0)
        {
            gameObject.SetActive(true);
            currentHealth = FullHealth;
            healthSlider.value = currentHealth;
        }*/
    }

    public void addHealth(float health)
    {
        if (health + currentHealth <= FullHealth)
            currentHealth += health;
        else currentHealth = FullHealth;

        healthSlider.value = currentHealth;
    }
}
