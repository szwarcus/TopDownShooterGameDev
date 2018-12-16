using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControler : MonoBehaviour
{
    public bool isFiring;
    public BulletController bullet;
    private float bulletSpeed;

    private float timeBetweenShots;
    private float shotCounter;

    private BalanceMenager BM;


    public Transform firePoint;
    // Start is called before the first frame update
    private void Awake()
    {
        BM = GameObject.FindGameObjectWithTag("GM").GetComponent<BalanceMenager>();
        if (BM == null)
            Debug.LogError("PlayerMovementScript: BalanceMenager not found!");
    }
    void Start()
    {
        bulletSpeed = BM.bulletSpeed;
        timeBetweenShots = BM.timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                newBullet.speed = bulletSpeed;
            }
        }
        else
        {
            shotCounter = 0;
        }

    }
}
