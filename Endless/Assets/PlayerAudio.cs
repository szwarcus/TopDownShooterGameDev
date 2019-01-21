using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip levelUpClip;
    public AudioClip hitClip;

    public AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = hitClip;
    }

    public void LevelUp()
    {
        musicSource.clip = levelUpClip;
        musicSource.Play();
    }

    public void Hit()
    {
        musicSource.clip = hitClip;
        musicSource.Play();
    }
}
