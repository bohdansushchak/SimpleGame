using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHit : MonoBehaviour {

    public float WeaponDamage;

    ProjectileControler PC;

    public GameObject explosionEffect;



	// Use this for initialization
	void Awake () {
        PC = GetComponentInParent<ProjectileControler>();

		
	}
	
	// Update is called once per frame
	void Update () {


		
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Shootable") || collision.gameObject.layer == LayerMask.NameToLayer("Ground")) {
            PC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable") || collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            PC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }



}
