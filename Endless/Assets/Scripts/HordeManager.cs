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
    private float HordeBaseSpawnChance = 0.5f;

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
        HordeBaseSpawnChance = BL.hordeSpawnRate;
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
            if (random > 1f - spawnChance)
            {
                Debug.Log("Spawn Horde!");
                spawnChance = 0f;
                float randomDir = Random.Range(0f, 1f);
                Direction dir;
                if (randomDir < 0.25f)
                {
                    dir = Direction.N;
                }
                else if (randomDir < 0.5f)
                {
                    dir = Direction.E;
                }
                else if (randomDir < 0.75f)
                {
                    dir = Direction.W;
                }
                else
                {
                    dir = Direction.S;
                }
                SpawnEnemy(1 + hordelevel * 2, dir);
                hordelevel += 1;
            }
            else
            {
                spawnChance = spawnChance + 0.02f * HordeBaseSpawnChance;
            }
        }
    }

    private void SpawnEnemy(int count, Direction direction)
    {
        Vector3 pos = new Vector3();
        switch (direction)
        {
            case Direction.E:
                pos = new Vector3(player.transform.position.x + 15, 0, player.transform.position.z);
                break;
            case Direction.S:
                pos = new Vector3(player.transform.position.x, 0, player.transform.position.z - 15);
                break;
            case Direction.W:
                pos = new Vector3(player.transform.position.x - 15, 0, player.transform.position.z);
                break;
            case Direction.N:
                pos = new Vector3(player.transform.position.x, 0, player.transform.position.z + 15);
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
