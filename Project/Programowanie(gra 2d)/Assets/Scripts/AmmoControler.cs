﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoControler : MonoBehaviour
{

    public int CountAmmo;
    public int IdAmmo;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.addAmmo(CountAmmo, IdAmmo);
            Destroy(gameObject);
        }

    }
}
