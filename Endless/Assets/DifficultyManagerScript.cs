using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManagerScript : MonoBehaviour
{
    public int mapDifficultyLevel = 0; // internal difficulty level of session
    public int mapLevel = 0; // number of maps generated
    public int difficultyChangePoint = 10; // when difficulty rise?

    public int gameDifficultyLevel; // external difficulty level set by the player

    [SerializeField]
    private BalanceLoader balanceLoader;

    // Start is called before the first frame update
    void Start()
    {
        LoadFromBalancer();
    }

    private void LoadFromBalancer()
    {
        gameDifficultyLevel = balanceLoader.startingDifficulty;
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
    }

    private void UpdateDifficulty()
    {

    }

}
