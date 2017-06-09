using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour {

    public string NextLevel;
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
            //Application.LoadLevel(NextLevel);
            SceneManager.LoadScene(NextLevel, LoadSceneMode.Single);
            

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
