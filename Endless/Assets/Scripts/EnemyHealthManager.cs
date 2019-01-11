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
        healthText.text = currentHealth.ToString()+"/"+health.ToString();
        moveSpeed = enemyManagerScript.EnemyMoveSpeed(enemyType);
        gameObject.GetComponent<NavMeshAgent>().speed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth<=0)
        {
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
        healthText.text = currentHealth.ToString() + "/" + health.ToString();
    }
}
