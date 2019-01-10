using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LoadMap : MonoBehaviour
{
    public List<MiniMap> miniMapList;
    public List<BigMap> bigMapList;
    private NavMeshSurface navMeshSurface;

    private int widthMiniMap = 10;
    private int heightMiniMap = 10;
    private int widthBigMap = 50;
    private int heightBigMap = 50;

    [SerializeField]
    private GameObject wall;
    [SerializeField]
    private GameObject zombie;
    [SerializeField]
    private GameObject chest;
    [SerializeField]
    private GameObject door;

    private void Awake()
    {
        navMeshSurface = GameObject.FindGameObjectWithTag("NavMesh").GetComponent<NavMeshSurface>();
        if(navMeshSurface == null)
        {
            Debug.LogError("LevelGenerator: no nav mash agent found!");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (miniMapList.Count == 0)
        {
            Debug.LogError("No miniMap added!");
        }
        if (bigMapList.Count == 0)
        {
            Debug.LogError("No bigMap added!");
        }
//        LoadingMiniMap(4, new Vector2(10,10));
        LoadingBigMap(0);
//        GameObject.FindGameObjectWithTag("Ground").transform.position = new Vector3(transform.position.x, GameObject.FindGameObjectWithTag("Ground").transform.position.y, transform.position.z);
//        navMeshSurface.BuildNavMesh();
    }

    public void LoadingMiniMap(int mapNumber, Vector2 position)
    {
        if (mapNumber > miniMapList.Count - 1)
        {
            Debug.LogWarning("Attempt to access a non-existent miniMap. Loading the base miniMap.");
            mapNumber = 0;
        }
        for(int i = 0; i < miniMapList[mapNumber].mapLayout.rows.Length; i++)
        {
            for (int j = 0; j < miniMapList[mapNumber].mapLayout.rows[i].row.Length; j++)
            {
                if(miniMapList[mapNumber].mapLayout.rows[i].row[j] > 0)
                {
                    if (miniMapList[mapNumber].mapLayout.rows[i].row[j] == 1)
                    {
                        Vector3 pos = new Vector3(i * 2 - widthMiniMap / 2f + position.x, 1f, j * 2 - heightMiniMap / 2f + position.y);
                        Instantiate(wall, pos, Quaternion.identity, transform);
                    }
                    else if (miniMapList[mapNumber].mapLayout.rows[i].row[j] == 2)
                    {
                        Vector3 pos = new Vector3(i * 2 - widthMiniMap / 2f + position.x, 1f, j * 2 - heightMiniMap / 2f + position.y);
                        Instantiate(chest, pos, Quaternion.identity, transform);
                    }
                    else if (miniMapList[mapNumber].mapLayout.rows[i].row[j] == 3)
                    {
                        Vector3 pos = new Vector3(i * 2 - widthMiniMap / 2f + position.x, 1.1f, j * 2 - heightMiniMap / 2f + position.y);
                        Instantiate(door, pos, Quaternion.identity, transform);
                    }
                    else if (miniMapList[mapNumber].mapLayout.rows[i].row[j] == 10)
                    {
                        if (Random.value >= 0.9f) // Should we spawn a zombie?
                        {
                            Vector3 pos = new Vector3(i * 2 - widthMiniMap / 2f + position.x, 3f, j * 2 - heightMiniMap / 2f + position.y);
                            Instantiate(zombie, pos, Quaternion.identity, transform);
                        }
                    }
                }
                else
                {
                    if (Random.value >= 1f) // Should we spawn a zombie?
                    {
                        // Spawn the zombie
//                        Vector3 pos = new Vector3(i * 2 - widthMiniMap / 2f + position.x, 1f, j * 2 - heightMiniMap / 2f + position.y);
//                        Instantiate(zombie, pos, Quaternion.identity, transform);
                    }
                }
            }
        }
    }
    public void LoadingBigMap(int mapNumber)
    {
        if (mapNumber > bigMapList.Count - 1)
        {
            Debug.LogWarning("Attempt to access a non-existent bigMap. Loading the base bigMap.");
            mapNumber = 0;
        }
        for (int i = 0; i < bigMapList[mapNumber].mapLayout.rows.Length; i++)
        {
            for (int j = 0; j < bigMapList[mapNumber].mapLayout.rows[i].row.Length; j++)
            {
                if (bigMapList[mapNumber].mapLayout.rows[i].row[j] > 0)
                {
                    Vector2 position = new Vector2(transform.position.x + i * 2 * 10 - widthBigMap +5f, transform.position.z + j * 2 * 10 - heightBigMap + 5f);
                    LoadingMiniMap(bigMapList[mapNumber].mapLayout.rows[i].row[j], position);
                }
            }
        }
    }
}
