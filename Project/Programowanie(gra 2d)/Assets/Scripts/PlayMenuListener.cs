using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayMenuListener : MonoBehaviour {

    public GameObject player;
    public Camera mainCamera;
    public string levelRestart;
    private bool deadPlayer;


    PlayerHealth playerHealth;
    PlayerController playerController;

  

    public void Resume()
    {
        if (deadPlayer == false)
        {
            Time.timeScale = 1.0f;
            gameObject.SetActive(false);
        }

    }
    public void Restart()
    {
        Time.timeScale = 1.0f;
        PlayerPrefs.DeleteAll();
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(levelRestart, LoadSceneMode.Single);
        
    }

    public void Save()
    {
        if (deadPlayer == false)
        {
            playerController = player.GetComponent<PlayerController>();
            playerHealth = player.GetComponent<PlayerHealth>();

            PlayerPrefs.DeleteAll();

            PlayerPrefs.SetInt("bullet2", playerController.Bullet2);
            PlayerPrefs.SetInt("bullet3", playerController.Bullet3);
            PlayerPrefs.SetInt("bullet4", playerController.Bullet4);

            PlayerPrefs.SetFloat("PlayerHealth", playerHealth.Health);

            PlayerPrefs.SetFloat("PlayerPosX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", player.transform.position.y);
            PlayerPrefs.SetFloat("PlayerPosZ", player.transform.position.z);

            PlayerPrefs.SetFloat("CameraPosX", mainCamera.transform.position.x);
            PlayerPrefs.SetFloat("CameraPosY", mainCamera.transform.position.y);
            PlayerPrefs.SetFloat("CameraPosZ", mainCamera.transform.position.z);

            PlayerPrefs.Save();

            Time.timeScale = 1.0f;
            gameObject.SetActive(false);
        }
    }

    public void Exit()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }

    public bool DeadPlayer
    {
        set { deadPlayer = value; }
    }






}
