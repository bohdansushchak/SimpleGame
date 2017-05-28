using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {


    public int LifeScore;
    public float FullHealth;
    public GameObject blood;

    float currentHealt;

    PlayerController controlMovement;

	// Use this for initialization
	void Start () {
        currentHealt = FullHealth;

        controlMovement = GetComponent<PlayerController>();
 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage)
    {
        if (damage <= 0) return;

        currentHealt -= damage;

        if (currentHealt <= 0)
            dead();
    } 

    public void dead()
    {
        Instantiate(blood, transform.position, transform.rotation);
        gameObject.SetActive(false);
        --LifeScore;

        if(LifeScore > 0)
        {
            gameObject.SetActive(true);
            currentHealt = FullHealth;
        }
    }


}
