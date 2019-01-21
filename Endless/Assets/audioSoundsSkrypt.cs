using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioSoundsSkrypt : MonoBehaviour
{
    public AudioClip pistolShootClip;
    public AudioClip autoRifleShootClip;
    public AudioClip dryShootClip;
    public AudioClip reloadClip;
    public AudioClip changeGunClip;

    public AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = pistolShootClip;
    }

    public void Reload()
    {
        musicSource.clip = reloadClip;
        musicSource.Play();
    }

    public void ChangeGun()
    {
        musicSource.clip = reloadClip;
        musicSource.Play();
    }

    public void Shoot(bool ammoOn, int guntype)
    {
        if(!ammoOn)
        {
            musicSource.clip = dryShootClip;
            musicSource.Play();
        }
        else if (guntype == 1)
        {
            musicSource.clip = pistolShootClip;
            musicSource.Play();
        }
        else if (guntype == 2)
        {
            musicSource.clip = autoRifleShootClip;
            musicSource.Play();
        }

    }
}
