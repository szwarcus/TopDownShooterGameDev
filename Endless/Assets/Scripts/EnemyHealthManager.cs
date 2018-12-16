using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int health = 120;
    private int currentHealth;
    public TextMesh healthText;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        healthText = GetComponentInChildren<TextMesh>();
        healthText.text = currentHealth.ToString()+"/"+health.ToString();
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
