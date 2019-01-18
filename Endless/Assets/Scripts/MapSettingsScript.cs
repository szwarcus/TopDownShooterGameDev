using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSettingsScript : MonoBehaviour
{
    [SerializeField]
    private DifficultyManagerScript difficultyManagerScript;

    void Start()
    {
        
    }

    public void MapUp()
    {
        difficultyManagerScript.MapLevelUp();
    }
}
