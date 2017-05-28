using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public float damage;
    public float damageRate;
    public float pushBackForce;

    public float nextDamage;

	// Use this for initialization
	void Start () {
        nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && nextDamage < Time.time)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(collision.transform);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, pushedObject.position.y - transform.position.y);
        pushDirection *= pushBackForce;
        Rigidbody2D pushBD = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushBD.velocity = Vector2.zero;
        pushBD.AddForce(pushDirection, ForceMode2D.Impulse);


    }
}
