using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioClip grandmaClip;
    public AudioClip zombieClip;
    public AudioClip hitClip;

    public AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = grandmaClip;
    }

    public void Grandma()
    {
        musicSource.clip = grandmaClip;
        musicSource.volume = 0.05f;
        musicSource.Play();
        musicSource.volume = 0.2f;
    }

    public void Zombie()
    {
        musicSource.clip = zombieClip;
        musicSource.Play();
    }

    public void Hit()
    {
        musicSource.clip = hitClip;
        musicSource.Play();
    }
}
