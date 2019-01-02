using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    [Header("Weapon Settings")]

    [Tooltip("Weapon name")]
    public string weaponName;

    [Tooltip("How much damage weapon will dealt with hit (10 to 100)")]
    [Range(10, 100)]
    public float weaponDamage;

    [Tooltip("How often weapon can attack per 1 second (0.1 to 2)")]
    [MyRange(0.1f, 2, 0.1f)]
    public float weaponAttackSpeed;

    [Tooltip("What type of weapon it is (true -> range weapon, false -> melee weapon")]
    public bool weaponAttackRange;
}
