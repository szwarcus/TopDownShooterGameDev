using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    public float attackSpeed;
    public bool attack = false;

    private EnemyManagerScript enemyManagerScript;

    private void Awake()
    {
        enemyManagerScript = GameObject.FindGameObjectWithTag("EM").GetComponent<EnemyManagerScript>();
        if (enemyManagerScript == null)
            Debug.LogError("No EnemyManagerScript found!");
    }

    private void Start()
    {
        damageToGive = enemyManagerScript.EnemyDamage(transform.parent.gameObject.GetComponent<EnemyHealthManager>().enemyType);
        attackSpeed = enemyManagerScript.EnemyAttackSpeed(transform.parent.gameObject.GetComponent<EnemyHealthManager>().enemyType);
        StartCoroutine(AttackON());
    }

    IEnumerator AttackON()
    {
        yield return new WaitForSeconds(1f);
        attack = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(attack)
            {
                other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
                attack = false;
                StartCoroutine(AttackON());
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attack)
            {
                other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
                attack = false;
                StartCoroutine(AttackON());
            }
        }
    }
}
