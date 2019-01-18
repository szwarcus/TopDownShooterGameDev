using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    [Header("Enemy Settings")]

    [Tooltip("Enemy name")]
    public string enemyName;

    [Tooltip("Enemy rarity (1 -> Common, 2 -> Rare, 3 -> Legendary)")]
    [Range(1, 3)]
    public int enemyClass;

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

    [Tooltip("What type of atack he use (true -> range weapon, false -> melee weapon")]
    public bool enemyAttackRange;

    [Tooltip("Distance between player and enemy when enemy move torwards player")]
    [MyRange(1f, 40f, 0.2f)]
    public float distance;

    [Tooltip("Points that player will receive for killing enemy")]
    [Range(10, 500)]
    public int score;

    [Tooltip("Enemy description")]
    public string enemyDescription;

}
