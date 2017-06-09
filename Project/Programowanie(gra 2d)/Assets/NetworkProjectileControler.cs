using UnityEngine;
using UnityEngine.Networking;

public class NetworkProjectileControler : NetworkBehaviour {
    public float speed;

    Rigidbody2D body;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        if (transform.localRotation.z > 0)
            body.AddForce(new Vector2(-1, 0) * speed, ForceMode2D.Impulse);
        else
            body.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void removeForce()
    {
        body.velocity = new Vector2(0, 0);
    }
}
