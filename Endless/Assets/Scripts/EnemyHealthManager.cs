using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealthManager : MonoBehaviour
{
    public int health = 120;
    private int currentHealth;
    public TextMesh healthText;
    public int enemyType;
    public float moveSpeed = 3.5f;
    public int scorePoints;

    public EnemyAudio audio;

    private EnemyManagerScript enemyManagerScript;

    private void Awake()
    {
        enemyManagerScript = GameObject.FindGameObjectWithTag("EM").GetComponent<EnemyManagerScript>();
        if (enemyManagerScript == null)
            Debug.LogError("No EnemyManagerScript found!");
        enemyType = Random.Range(0, 2);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyManagerScript.EnemyHitPoints(enemyType);
        health = currentHealth;
        healthText = GetComponentInChildren<TextMesh>();
        healthText.text = currentHealth.ToString() + "/" + health.ToString();
        moveSpeed = enemyManagerScript.EnemyMoveSpeed(enemyType);
        scorePoints = enemyManagerScript.EnemyScore(enemyType);
        if (gameObject.GetComponent<EnemyScript>().Horde == false)
            gameObject.GetComponent<NavMeshAgent>().speed = moveSpeed;
        else
            gameObject.GetComponent<NavMeshAgent>().speed = moveSpeed * 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth<=0)
        {
            GameObject.FindGameObjectWithTag("PLM").GetComponent<PlayerLevel>().GainXp(1);
            GameObject.FindGameObjectWithTag("SM").GetComponent<ScoreManager>().AddScore(scorePoints);
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damage)
    {
        audio.Hit();
        currentHealth -= damage;
        healthText.text = currentHealth.ToString() + "/" + health.ToString();

    }
}
