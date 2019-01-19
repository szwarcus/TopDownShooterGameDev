using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public List<Enemy> enemies;

    public float enemyMoveSpeedChange;
    public int enemyHitPointsChange;
    public int enemyDamageChange;
    public float enemyAttackSpeedChange;
    [SerializeField]
    private int gDL = 0;

    public bool loadDone = false;

    [SerializeField]
    private DifficultyManagerScript difficultyManagerScript;

    private void Awake()
    {
        
    }

    private void Start()
    {
        StartCoroutine(LoadData());
    }

    IEnumerator LoadData()
    {
        yield return new WaitForSeconds(1);
        if(difficultyManagerScript.loadDone == true)
        {
            gDL = difficultyManagerScript.gameDifficultyLevel;
            loadDone = true;
            StopCoroutine(LoadData());
        }

    }

    public int EnemyHitPoints(int nr)
    {
        int HP = 0;
        HP = enemies[nr].enemyHitPoints + difficultyManagerScript.mapDifficultyLevel * enemyHitPointsChange;
        switch (gDL)
        {
            case 1:
                HP = (int)(HP * 0.5);
                break;
            case 2:
                HP = (int)(HP * 0.75);
                break;
            case 3:
                HP = (int)(HP * 1);
                break;
            case 4:
                HP = (int)(HP * 1.25);
                break;
            case 5:
                HP = (int)(HP * 2.5);
                break;
        }
        return HP;
    }

    public int EnemyDamage(int nr)
    {
        int dmg = 0;
        dmg = enemies[nr].enemyDamage + difficultyManagerScript.mapDifficultyLevel * enemyDamageChange;
        switch (gDL)
        {
            case 1:
                dmg = (int)(dmg * 0.6);
                break;
            case 2:
                dmg = (int)(dmg * 0.8);
                break;
            case 3:
                dmg = (int)(dmg * 1);
                break;
            case 4:
                dmg = (int)(dmg * 1.25);
                break;
            case 5:
                dmg = (int)(dmg * 2);
                break;
        }
        return dmg;
    }

    public float EnemyMoveSpeed(int nr)
    {
        float ms = 0;
        ms = enemies[nr].enemyMoveSpeed + difficultyManagerScript.mapDifficultyLevel * enemyMoveSpeedChange;
        return ms;
    }

    public float EnemyAttackSpeed(int nr)
    {
        float ats = 0;
        ats = enemies[nr].enemyAttackSpeed + difficultyManagerScript.mapDifficultyLevel * enemyAttackSpeedChange;
        return ats;
    }

    public float EnemyDistance(int nr)
    {
        float dist = 0;
        dist = enemies[nr].distance;
        return dist;
    }

    public int EnemyScore(int nr)
    {
        int score = 0;
        score = enemies[nr].score + difficultyManagerScript.mapDifficultyLevel * 3;
        return score;
    }

}
