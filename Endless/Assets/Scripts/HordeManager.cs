using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeManager : MonoBehaviour
{
    [SerializeField]
    private BalanceLoader BL;
    private EnemyManagerScript EM;
    [SerializeField]
    private List<int> enemiesTags;

    private int mapDifficultyLevel = 0;
    private int maxLevelSafeFromHorde;
    [SerializeField]
    private float spawnChance = 0.5f;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject zombie;

    private int hordelevel = 1;

    enum Direction
    {
        N,
        E,
        S,
        W
    }

    private void Awake()
    {
        EM = GameObject.FindGameObjectWithTag("EM").GetComponent<EnemyManagerScript>();
        if(EM == null)
        {
            Debug.LogError("HordeManager: No EnemyManagerScript found!");
        }
    }

    private void Start()
    {
        maxLevelSafeFromHorde = BL.maxLevelSafeFromHorde;
    }

    public void UpdateMapDifficultyLevel(int value)
    {
        mapDifficultyLevel = value;
    }

    public void SpawnHorde()
    {
        if(mapDifficultyLevel >= maxLevelSafeFromHorde)
        {
            float random = Random.Range(0f, 1f);
            if (random > 0f - spawnChance)
            {
                Debug.Log("Spawn Horde!");
                spawnChance = 0f;
                SpawnEnemy(1 + hordelevel * 2, Direction.N);
                hordelevel += 1;
            }
            else
            {
                spawnChance = spawnChance + 0.05f;
            }
        }
    }

    private void SpawnEnemy(int count, Direction direction)
    {
        Vector3 pos = new Vector3();
        switch (direction)
        {
            case Direction.N:
                pos = new Vector3(player.transform.position.x + 10, 0, player.transform.position.z);
                break;
            case Direction.E:
                pos = new Vector3(player.transform.position.x, 0, player.transform.position.z - 10);
                break;
            case Direction.S:
                pos = new Vector3(player.transform.position.x - 10, 0, player.transform.position.z);
                break;
            case Direction.W:
                pos = new Vector3(player.transform.position.x, 0, player.transform.position.z + 10);
                break;
        }
        GameObject clone = Instantiate(zombie, pos, player.transform.rotation);
        clone.GetComponent<EnemyScript>().SetHorde(true);
        if(count > 1)
        {
            SpawnEnemy(count - 1, direction);
        }
    }


}
