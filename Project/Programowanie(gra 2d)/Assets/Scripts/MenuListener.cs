using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuListener : MonoBehaviour {


    public GameObject PLoadLevel;
    public GameObject PSettings;

    

	public void NewGame()
    {

        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("level1", LoadSceneMode.Single);
        
    }

    public void Resume()
    {
        string level = PlayerPrefs.GetString("ResumeLevel", "level1"); 
        SceneManager.LoadScene(level);
    } 

    public void LoadLevel()
    {
        if (PSettings.activeSelf)
            PSettings.SetActive(false);

        PLoadLevel.SetActive(!PLoadLevel.activeSelf);
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene("Multiplayer_Level", LoadSceneMode.Single);
    } 

    public void Settings()
    {
        if (PLoadLevel.activeSelf)
            PLoadLevel.SetActive(false);

        PSettings.SetActive(!PSettings.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene("level1", LoadSceneMode.Single);

    }

    public void Level2()
    {
        SceneManager.LoadScene("level2", LoadSceneMode.Single);
    }

    public void Level3()
    {
        //Application.LoadLevel(3); // для загрузки першого левелу
    }

    public void Level4()
    {
        //Application.LoadLevel(4); // для загрузки першого левелу
    }

    public void Level5()
    {
        //Application.LoadLevel(5); // для загрузки першого левелу
    }

    public void setMusic(float value)
    {
        Settings_value.music = value;
    }

    public void setSound(float value)
    {
        Settings_value.sound = value;
    }
}
