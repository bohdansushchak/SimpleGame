using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextLevel : MonoBehaviour {

    public int NextLevel;
    public float timeWait;

    float time;
    bool isFinish;

    // Use this for initialization
    void Start()
    {
        isFinish = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (time < Time.time && isFinish)
            Application.LoadLevel(NextLevel);

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isFinish)
        {
            time = Time.time + timeWait;
            isFinish = true;
        }
    }
}
