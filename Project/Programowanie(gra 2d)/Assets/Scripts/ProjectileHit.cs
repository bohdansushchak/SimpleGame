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
        if(collision.gameObject.layer == LayerMask.NameToLayer("Shootable")) {
            PC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (collision.tag == "Enemy") {
                EnemyHealth hurtEnemy = collision.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDamage(WeaponDamage);
  
            }
        }
    }

    /*void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable")){
            PC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (collision.tag == "Enemy")
            {
                EnemyHealth hurtEnemy = collision.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDamage(WeaponDamage);
            }
        }
    }*/

   



}
