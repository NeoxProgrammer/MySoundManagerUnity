using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public Sound[] musicSounds; 

    public Sound[] sfxSounds;

    public AudioSource musicSource;
    public AudioSource sfxSource; 
        






    private void Awake()
    {
       if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.my_name == name);

        if(s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
            return;
        }

        musicSource.clip = s.clip;
        musicSource.Play();
    }


    private void Start()
    {
        PlayMusic("MainTheme");

    }



    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.my_name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
            return;

        }
        sfxSource.PlayOneShot(s.clip);

    }



}

