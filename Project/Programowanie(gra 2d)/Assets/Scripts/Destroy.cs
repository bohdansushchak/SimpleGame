using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {


    public AudioClip sound;
    AudioSource audioSource;
    float volume;

    public float timeAlive;
    // Use this for initialization
    void Awake() {
        if (sound != null) { 
            volume = PlayerPrefs.GetFloat("AudioVolume", 1f);
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound, volume);
        }
        Destroy(gameObject, timeAlive);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
