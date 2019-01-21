using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSkrypt : MonoBehaviour
{
    public AudioClip musicClip;

    public AudioSource musicSource;


    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.Play();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
