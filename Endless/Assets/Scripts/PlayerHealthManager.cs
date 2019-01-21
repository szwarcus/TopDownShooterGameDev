using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    private int maxHealth;
    public int startingHealth;
    private int currentHealth;
    public GameObject healthBarObject;

    public float flashLength;
    private float flashCounter;

    private Renderer rend;
    private Color storedColor;

    public Text maxHpText;
    public Text currentHpText;

    public PlayerAudio audio;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = startingHealth;
        currentHealth = startingHealth;
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
        healthBarObject.GetComponent<Slider>().value = currentHealth;
        UpdateCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth<=0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("GameOverScene");
        }


        if (flashCounter>0)
        {
            flashCounter -= Time.deltaTime;
            if(flashCounter<=0)
            {
                rend.material.SetColor("_Color",storedColor);
            }
        }
    }

    public void HurtPlayer(int damageAmount)
    {
        audio.Hit();
        currentHealth -= damageAmount;
//        healthBarObject.GetComponent<Slider>().value = currentHealth;

        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.white);
        UpdateCanvas();
    }

    public void ChangeHealth(int value)
    {
        int oldMaxHP = maxHealth;
        maxHealth = startingHealth + value;
        currentHealth = currentHealth + ( -oldMaxHP + maxHealth);
        UpdateCanvas();
    }

    private void UpdateCanvas()
    {
        maxHpText.text = maxHealth.ToString();
        currentHpText.text = currentHealth.ToString();
        healthBarObject.GetComponent<Slider>().maxValue = maxHealth;
        healthBarObject.GetComponent<Slider>().value = currentHealth;
    }
}
