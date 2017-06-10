using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour {

    public AudioClip shoot_p1;
    public AudioClip shoot_p2;
    public AudioClip shoot_p3;
    public AudioClip shoot_p4;

    public AudioClip walk;
    public AudioClip jump;

    AudioSource audio;

    private float musicVolume;
    private float soundVolume;
    private float timeJump;

    // Use this for initialization
    void Awake () {
        audio = GetComponent<AudioSource>();
        soundVolume = PlayerPrefs.GetFloat("AudioVolume", 1f);

  
    }
    public void Jump()
    {
        if(Time.time > timeJump)
        {
            timeJump = Time.time + 1f;
            audio.PlayOneShot(jump, soundVolume);

        }
       
    }
    public void Walk()
    {
        audio.PlayOneShot(walk, soundVolume);
    }

    public void Shoot_p1()
    {
        audio.PlayOneShot(shoot_p1, soundVolume);
    }

    public void Shoot_p2()
    {
        audio.PlayOneShot(shoot_p2, soundVolume);
    }

    public void Shoot_p3()
    {
        audio.PlayOneShot(shoot_p3, soundVolume);
    }

    public void Shoot_p4()
    {
        audio.PlayOneShot(shoot_p4, soundVolume);
    }

}
