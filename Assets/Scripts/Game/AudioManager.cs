using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource musicSource;
    public AudioClip backgroundMusic;
    public AudioSource startSource;
    public AudioClip startSound;
    public AudioSource deathSource;
    public AudioClip deathSound;
    public AudioSource restartSource;
    public AudioClip restartSound;
    public AudioSource collectSource;
    public AudioClip collectSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Start music once
            if (backgroundMusic != null)
            {
                musicSource.clip = backgroundMusic;
                musicSource.loop = true;
                musicSource.Play();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    public void PlayMusic()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }
}
