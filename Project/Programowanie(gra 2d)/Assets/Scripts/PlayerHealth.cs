using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {


    //public int LifeScore;
    public float fullHealth;
    public GameObject blood;
    public GameObject playerMenu;
    PlayMenuListener menu;

    float currentHealth;

    public Slider healthSlider;

	// Use this for initialization
	void Start () {

        currentHealth = PlayerPrefs.GetFloat("PlayerHealth", fullHealth);
        menu = playerMenu.GetComponent<PlayMenuListener>();


        healthSlider.maxValue = fullHealth;
        healthSlider.value = currentHealth;

 
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
        menu.DeadPlayer = true;
        playerMenu.SetActive(true);


        //Destroy(gameObject, 1f);
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
        if (health + currentHealth <= fullHealth)
            currentHealth += health;
        else currentHealth = fullHealth;

        healthSlider.value = currentHealth;
    }

    public float Health
    {
        get { return currentHealth; }
    }
}
