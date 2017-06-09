using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour {

    public string NextLevel;
    public float timeWait;

    private PlayerController playerController;
    private PlayerHealth playerHealth;

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
        {
            SceneManager.LoadScene(NextLevel, LoadSceneMode.Single);
   
            PlayerPrefs.SetInt("bullet2", playerController.Bullet2);
            PlayerPrefs.SetInt("bullet3", playerController.Bullet3);
            PlayerPrefs.SetInt("bullet4", playerController.Bullet4);
            PlayerPrefs.SetFloat("PlayerHealth", playerHealth.Health);

        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isFinish)
        {
            time = Time.time + timeWait;
            isFinish = true;
            playerController = collision.GetComponent<PlayerController>();
            playerHealth = collision.GetComponent<PlayerHealth>();



        }
    }
}
