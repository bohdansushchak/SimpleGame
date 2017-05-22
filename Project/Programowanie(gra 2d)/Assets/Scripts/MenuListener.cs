using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuListener : MonoBehaviour {


    public GameObject PLoadLevel;
    public GameObject PSettings;

	public void NewGame()
    {
        //Application.LoadLevel(1); // для загрузки першого левелу
    }

    public void Resume()
    {

    } 

    public void LoadLevel()
    {
        if (PSettings.activeSelf)
            PSettings.SetActive(false);

        PLoadLevel.SetActive(!PLoadLevel.activeSelf);
    }

    public void Multiplayer()
    {

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
        //Application.LoadLevel(1); // для загрузки першого левелу
    }

    public void Level2()
    {
        //Application.LoadLevel(2); // для загрузки першого левелу
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
