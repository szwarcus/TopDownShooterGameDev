using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    private float bulletLifeTime=2;

    public int damageToGive;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        bulletLifeTime -= Time.deltaTime;
        if(bulletLifeTime<=0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            //Destroy(other.gameObject);
            Destroy(gameObject);
            //GameObject instantiatedParticleSystem = Instantiate(particleExplosionSystem, transform.position, transform.rotation);
            //Destroy(instantiatedParticleSystem, 1f);
            //PlayerScore.playerScore += bulletScore;

            // CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        }
    }
}
