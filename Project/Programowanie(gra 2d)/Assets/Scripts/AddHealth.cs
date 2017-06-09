using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour {

    public float health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") { 
        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();
        player.addHealth(health);
        Destroy(gameObject);
    }

    }
}
