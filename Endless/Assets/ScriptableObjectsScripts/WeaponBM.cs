using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponBM : ScriptableObject
{
    [Header("Weapon Settings")]

    [Tooltip("How much damage weapon will dealt with hit (10 to 100)")]
    [Range(10, 100)]
    public int weaponDamage;

    [Tooltip("How often weapon can attack per 1 second (0.1 to 2)")]
    [MyRange(0.01f, 2, 0.01f)]
    public float weaponAttackSpeed;

    [Tooltip("What type of weapon it is (true -> range weapon, false -> melee weapon")]
    public bool weaponAttackRange;

    [Tooltip("Texture of weapon (will be next to ammo)")]
    public Sprite weaponSprite;

    [Tooltip("Total max ammunition")]
    [Range(10, 1000)]
    public int totalMaxAmmo;

    [Tooltip("Magazine ammunition")]
    [Range(10, 1000)]
    public int magazineAmmo;

    [Tooltip("Ammuntion after getting up this")]
    [Range(10, 1000)]
    public int currentAmmo;

    [Tooltip("Time to reload the weapon")]
    [Range(0, 10)]
    public int reloadTime;
}
