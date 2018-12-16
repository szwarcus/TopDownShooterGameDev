﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            //GameObject instantiatedParticleSystem = Instantiate(particleExplosionSystem, transform.position, transform.rotation);
            //Destroy(instantiatedParticleSystem, 1f);
            //PlayerScore.playerScore += bulletScore;

            // CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        }
    }
}
