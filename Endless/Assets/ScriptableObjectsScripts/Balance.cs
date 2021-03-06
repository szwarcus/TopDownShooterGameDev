﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Balance", menuName = "Balance")]
public class Balance : ScriptableObject
{
    [Header("Enemy starting Settings")]

    [Tooltip("How often opponent will appear (in % from 10 to 100)")]
    [Range(10, 100)]
    public int enemySpawnRate;

    [Tooltip("How fast opponent will move (1 -> very slow walking, 2 -> slow walking, 3 -> walking, 4 -> fast walking, 5 -> very fast walking)")]
    [Range(1, 5)]
    public int enemyMoveSpeed;

    [Tooltip("How much life opponent will have (10 to 200)")]
    [Range(10, 200)]
    public int enemyHitPoints;

    [Tooltip("How much damage opponent will dealt with each hit (10 to 50)")]
    [Range(10, 50)]
    public int enemyDamage;

    [Tooltip("How often opponent will attack per 1 second (0.1 to 2)")]
    [MyRange(0.1f, 10, 0.2f)]
    public float enemyAttackSpeed = 5f;



    [Header("Player starting Settings")]

    [Tooltip("How fast player will move (1 to 5)")]
    [Range(1, 5)]
    public int playerMoveSpeed;

    [Tooltip("How much life player will have (50 to 200)")]
    [Range(50, 200)]
    public int playerHitPoints;

    [Header("Starting weapon Settings")]

    [Tooltip("How much damage weapon will dealt with hit (10 to 100)")]
    [Range(10, 100)]
    public float weaponDamage;

    [Tooltip("How often weapon can attack per 1 second (0.1 to 2)")]
    [Range(0.1f, 2)]
    public float weaponAttackSpeed;

    [Tooltip("What type of weapon it is (true -> range weapon, false -> melee weapon")]
    public bool weaponAttackRange;



    [Header("Leveling Settings")]

    [Tooltip("Amount of experience to first level")]
    [Range(5, 20)]
    public int experiencePoints;

    [Tooltip("Experience increase between levels")]
    [Range(0.2f, 0.3f)]
    public float experiencePointsChange;

    [Tooltip("Amount of hit points increase per point")]
    [Range(1, 3)]
    public int HitPointsUp;

    [Tooltip("Amount of damage increase per point")]
    [Range(1, 3)]
    public int damageUp;

    [Tooltip("Amount of movement speed increase per point")]
    [MyRange(0.01f, 0.2f, 0.005f)]
    public float speedUp;



    [Header("Difficulty progress level Settings")]

    [Tooltip("The number of levels generated after which internal level of difficulty will be increased")]
    [Range(3, 20)]
    public int changeRate;

    [Tooltip("The number of progress levels after which horde will spawn")]
    [Range(3, 5)]
    public int hordeSpawnRate;

    [Tooltip("The number of progress level before which horde will never spawn")]
    [Range(1, 5)]
    public int maxLevelSafeFromHorde;

    [Header("Starting difficulty level")]

    [Tooltip("Starting difficulty level:\n" +
        "1 -> very easy (enemy: -50% HP, -40%DMG. Score: -90%),\n" +
        "2 -> easy (enemy: -25% HP, -20%DMG. Score: -45%),\n" +
        "3 -> normal , 4 -> hard (enemy: +50% HP, +25%DMG. Score: +60%),\n" +
        "5 -> impossibru (enemy: +250% HP, +100%DMG. Score: +150%)")]
    [MyRangeLevelString(1,5,1)]
    public int startingDifficulty;
}
