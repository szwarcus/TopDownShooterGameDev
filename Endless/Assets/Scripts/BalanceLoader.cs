using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceLoader : MonoBehaviour
{

    public Balance balance;

    public int enemySpawnRate;
    public int enemyMoveSpeed;
    public int enemyHitPoints;
    public int enemyDamage;
    public float enemyAttackSpeed;
    public int playerMoveSpeed;
    public int playerHitPoints;
    public float weaponDamage;
    public float weaponAttackSpeed;
    public bool weaponAttackRange;
    public int experiencePoints;
    public float experiencePointsChange;
    public int HitPointsUp;
    public int damageUp;
    public float speedUp;
    public int changeRate;
    public int hordeSpawnRate;
    public int maxLevelSafeFromHorde;
    public int startingDifficulty;

    public bool loadDone = false;

    void Start()
    {
        this.enemySpawnRate = balance.enemySpawnRate;
        this.enemyMoveSpeed = balance.enemyMoveSpeed;
        this.enemyHitPoints = balance.enemyHitPoints;
        this.enemyDamage = balance.enemyDamage;
        this.enemyAttackSpeed = balance.enemyAttackSpeed;
        this.playerMoveSpeed = balance.playerMoveSpeed;
        this.playerHitPoints = balance.playerHitPoints;
        this.weaponDamage = balance.weaponDamage;
        this.weaponAttackSpeed = balance.weaponAttackSpeed;
        this.weaponAttackRange = balance.weaponAttackRange;
        this.experiencePoints = balance.experiencePoints;
        this.experiencePointsChange = balance.experiencePointsChange;
        this.HitPointsUp = balance.HitPointsUp;
        this.damageUp = balance.damageUp;
        this.speedUp = balance.speedUp;
        this.changeRate = balance.changeRate;
        this.hordeSpawnRate = balance.hordeSpawnRate;
        this.maxLevelSafeFromHorde = balance.maxLevelSafeFromHorde;
        this.startingDifficulty = balance.startingDifficulty;
        loadDone = true;
    }

}
