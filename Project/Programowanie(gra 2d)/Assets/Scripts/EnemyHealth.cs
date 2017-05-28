using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float MaxHealth;

    float currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = MaxHealth;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            dead();
        }
    }

    void dead()
    {
        Destroy(gameObject);
    }
}
