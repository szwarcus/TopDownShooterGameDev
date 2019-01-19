using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int gDL = 0;
    [SerializeField]
    private int score;

    public Text scoreText;

    public int Score
    {
        get
        {
            return score;
        }
    }

    private void Start()
    {
        gDL = GameObject.FindGameObjectWithTag("DM").GetComponent<DifficultyManagerScript>().gameDifficultyLevel;
        UpdateScoreText();
    }

    public void AddScore(int value)
    {
        switch (gDL)
        {
            case 1:
                score += (int)(value * 0.1);
                break;
            case 2:
                score += (int)(value * 0.55);
                break;
            case 3:
                score += (int)(value * 1);
                break;
            case 4:
                score += (int)(value * 1.6);
                break;
            case 5:
                score += (int)(value * 2.5);
                break;
        }
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
