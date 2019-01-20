using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunControler : MonoBehaviour
{
    public bool isFiring;
    public BulletController bullet;
    private float bulletSpeed;
    public int skillDamage;

    private float timeBetweenShots;
    private float nextFire;
    private float shotCounter;

    public WeaponManager we1;
    public WeaponBM choosedWeapon;
    public Image weaponImage;
    public Text ammunitionText;


    public Transform firePoint;
  
    void Start()
    {
        bulletSpeed = 10;

    }

    public void UpdateDamage(int value)
    {
        skillDamage = value;
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenShots = choosedWeapon.weaponAttackSpeed;
        weaponImage.sprite = choosedWeapon.weaponSprite;
        ammunitionText.text = choosedWeapon.currentAmmo.ToString() + "/" + choosedWeapon.totalMaxAmmo.ToString();
        if (isFiring && choosedWeapon.currentAmmo>0)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                Shoot();

            }
        }
        else
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + timeBetweenShots;
                shotCounter =0;
            }
        }

    }
    void Shoot()
    {
        BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        newBullet.speed = bulletSpeed;
        newBullet.skillDamage = skillDamage + choosedWeapon.weaponDamage;
        choosedWeapon.currentAmmo--;
    }
    public void Reload()
    {
        if (choosedWeapon.currentAmmo<choosedWeapon.magazineAmmo && choosedWeapon.totalMaxAmmo>0)
        {
            int ammoToAdd = choosedWeapon.magazineAmmo - choosedWeapon.currentAmmo;
            if (ammoToAdd<choosedWeapon.totalMaxAmmo)
            {
                choosedWeapon.currentAmmo += ammoToAdd;
                choosedWeapon.totalMaxAmmo -= ammoToAdd;
            }
            else
            {
                choosedWeapon.currentAmmo = choosedWeapon.totalMaxAmmo;
                choosedWeapon.totalMaxAmmo = 0;
            }
        }
    }
}
