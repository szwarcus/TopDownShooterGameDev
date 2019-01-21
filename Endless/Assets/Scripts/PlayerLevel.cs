using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    private GameObject player;

    private int str = 0;
    private int agi = 0;
    private int vit = 0;

    [SerializeField] 
    private int hpPerPoint = 3;
    [SerializeField]
    private int dmgPerPoint = 1;
    [SerializeField]
    private float speedPerPoint = 0.1f;

    private int freePoints = 0;

    private int exp = 0;
    private float expChangeRatio = 0.2f;

    private int level = 1;

    private int nextLevelExp;
    private int nextLevelExpBase = 10;
    private int currentLevelExp = 0;
    private int globalExp = 0;

    public Text nextLevelExpText;
    public Text currentExpText;
    public Slider expSlider;

    public Text strText;
    public Text agiText;
    public Text vitText;
    public Text freePointsText;

    public PlayerAudio audio;

    enum Stat
    {
        str,
        agi,
        vit
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            Debug.LogError("Playerlevel: No player game object found!");
        }
        nextLevelExp = nextLevelExpBase;
        UpdateCanvas(); 
    }

    private void Start()
    {
        StartCoroutine(LoadData());
    }

    IEnumerator LoadData()
    {
        yield return new WaitForSeconds(1);
        if (GameObject.FindGameObjectWithTag("BM").GetComponent<BalanceLoader>().loadDone == true)
        {
            hpPerPoint = GameObject.FindGameObjectWithTag("BM").GetComponent<BalanceLoader>().HitPointsUp;
            dmgPerPoint = GameObject.FindGameObjectWithTag("BM").GetComponent<BalanceLoader>().damageUp;
            speedPerPoint = GameObject.FindGameObjectWithTag("BM").GetComponent<BalanceLoader>().speedUp;
            expChangeRatio = GameObject.FindGameObjectWithTag("BM").GetComponent<BalanceLoader>().experiencePointsChange;
            nextLevelExpBase = GameObject.FindGameObjectWithTag("BM").GetComponent<BalanceLoader>().experiencePoints;
            nextLevelExp = nextLevelExpBase;
            UpdateCanvas();
            StopCoroutine(LoadData());
        }
    }

    private void Update()
    {
        GetInput();
    }

    private void CalcExpToNextLevel()
    {
        nextLevelExp += (int)(nextLevelExpBase * expChangeRatio);
    }

    private void LevelUp()
    {
        audio.LevelUp();
        AddPassivePoint();
        level += 1;
        currentLevelExp = currentLevelExp - nextLevelExp;
        CalcExpToNextLevel();
        UpdateCanvas();
    }

    public void GainXp(int value)
    {
        currentLevelExp += value;
        globalExp += value;
        Debug.Log("Get " + value + " EXP! EXP to next level -> " + (nextLevelExp - currentLevelExp));
        UpdateCanvas();
        if (currentLevelExp >= nextLevelExp)
        {
            Debug.Log("LevelUp!");
            LevelUp(); 
        }
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if(freePoints > 0)
            {
                freePoints -= 1;
                str += 1;
                UpdateStats(Stat.str);
            }
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (freePoints > 0)
            {
                freePoints -= 1;
                agi += 1;
                UpdateStats(Stat.agi);
            }
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            if (freePoints > 0)
            {
                Debug.Log("Vit UP!");
                freePoints -= 1;
                vit += 1;
                UpdateStats(Stat.vit);
            }
        }
        if (Input.GetKeyDown(KeyCode.F9))
        {
            AddPassivePoint();
        }
    }

    private void UpdateStats(Stat type)
    { 
        UpdateCanvas();
        switch (type)
        {
            case Stat.str:
                player.transform.GetChild(0).GetChild(0).GetComponent<GunControler>().UpdateDamage(str * dmgPerPoint);
                break;
            case Stat.agi:
                player.GetComponent<PlayerMovementScript>().UpdateSpeed(agi * speedPerPoint);
                break;
            case Stat.vit:
                player.GetComponent<PlayerHealthManager>().ChangeHealth(vit * hpPerPoint);
                break;
        }
    }

    public void AddPassivePoint()
    {
        freePoints += 1;
        Debug.Log("Add free point");
        UpdateCanvas();
    }

    private void UpdateCanvas()
    {
        nextLevelExpText.text = nextLevelExp.ToString();
        currentExpText.text = currentLevelExp.ToString();
        expSlider.maxValue = nextLevelExp;
        expSlider.value = currentLevelExp;
        strText.text = str.ToString();
        agiText.text = agi.ToString();
        vitText.text = vit.ToString();
        freePointsText.text = freePoints.ToString(); 
    }


}
