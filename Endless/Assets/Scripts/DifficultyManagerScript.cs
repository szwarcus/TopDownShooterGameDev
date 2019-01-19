using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManagerScript : MonoBehaviour
{
    public int mapDifficultyLevel = 0; // internal difficulty level of session
    public int mapLevel = 0; // number of maps generated
    public int difficultyChangePoint = 10; // when difficulty rise?

    public int gameDifficultyLevel; // external difficulty level set by the player

    public bool loadDone = false;

    [SerializeField]
    private BalanceLoader balanceLoader;

    [SerializeField]
    private HordeManager HM;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadData());
    }

    IEnumerator LoadData()
    {
        yield return new WaitForSeconds(1);
        if (balanceLoader.loadDone == true)
        {
            gameDifficultyLevel = balanceLoader.startingDifficulty;
            difficultyChangePoint = balanceLoader.changeRate;
            loadDone = true;
            StopCoroutine(LoadData());
        }
    }

    public void MapLevelUp()
    {
        mapLevel = mapLevel + 1;
        if(mapLevel == difficultyChangePoint)
        {
            mapLevel = 0;
            mapDifficultyLevel = mapDifficultyLevel + 1;
            UpdateDifficulty();
        }
        HM.SpawnHorde();
    }

    private void UpdateDifficulty()
    {
        HM.UpdateMapDifficultyLevel(mapDifficultyLevel);
    }

}
