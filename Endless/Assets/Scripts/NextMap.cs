using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMap : MonoBehaviour {
    /*
     * TODO: -
     * Skrypt służy do generacji nowego sektora mapy oraz usuwania jeśli znajduje się w znacznej odległości od gracza.
     */

    public bool top = false, bottom = false, left = false, right = false;
    private float mapWidth, mapHeight;
    private float camWidth, camHeight;

    [SerializeField]
    private float offset = 1f;

    [SerializeField]
    private GameObject map;

    private GameObject player;


    private void Awake()
    {
        top = false;
        bottom = false;
        left = false;
        right = false;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            Debug.LogError("NextMap: player not found!");
        mapWidth = 2 * 50; // transform.GetComponent<LevelGenerator>().width;
        mapHeight = 2 * 50; // transform.GetComponent<LevelGenerator>().height;
        camHeight = 2f * Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }
	// Update is called once per frame
	void Update () {
        CheckNewMap();

        if(player.transform.position.x > transform.position.x + 100 ||
           player.transform.position.x < transform.position.x - 100 ||
           player.transform.position.z > transform.position.z + 100 ||
           player.transform.position.z < transform.position.z - 100)
        {
            DestroySector();
        }
    }

    // Funkcja pozwala na sprawdzenie czy któryś z istniejących sektorów jest sąsiadem tego sektora (sąsiad rozumiany poprzez 4 kierunki góra, dół, lewo i prawo ale nie na ukos)
    public void CheckNeighbors()
    {
        for(int i = 0; i < map.transform.parent.transform.childCount; i++) // wykonaj dla każdego sektora
        {
            Vector3 childPos = map.transform.parent.transform.GetChild(i).transform.position;
            if(childPos.z == transform.position.z + mapHeight && childPos.x == transform.position.x)
            {
//                Debug.Log("Sąsiad u góry");
                top = true;
                map.transform.parent.transform.GetChild(i).GetComponent<NextMap>().bottom = true;
            }
            else if (childPos.z == transform.position.z - mapHeight && childPos.x == transform.position.x)
            {
//                Debug.Log("Sąsiad na dole");
                bottom = true;
                map.transform.parent.transform.GetChild(i).GetComponent<NextMap>().top = true;
            }
            else if (childPos.x == transform.position.x + mapWidth && childPos.z == transform.position.z)
            {
//                Debug.Log("Sąsiad na prawo");
                right = true;
                map.transform.parent.transform.GetChild(i).GetComponent<NextMap>().left = true;
            }
            else if (childPos.x == transform.position.x - mapWidth && childPos.z == transform.position.z)
            {
//                Debug.Log("Sąsiad na lewo");
                left = true;
                map.transform.parent.transform.GetChild(i).GetComponent<NextMap>().right = true;
            }
        }
    }

    // Funkcja sprawdza czy nowy sektor powinien zostać stworzony i tworzy go
    private void CheckNewMap()
    {
        if (player.transform.position.z > transform.position.z + mapHeight / 2 - offset - camHeight / 2 &&
            player.transform.position.z < transform.position.z + mapHeight &&
            player.transform.position.x > transform.position.x - mapWidth / 2 + offset - camWidth / 2 &&
            player.transform.position.x < transform.position.x + mapWidth / 2 - offset + camWidth / 2 &&
            top == false)
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + mapHeight);
            GameObject clone = Instantiate(map, newPos, Quaternion.identity, transform.parent);
            while(clone.transform.childCount != 0)
            {
                DestroyImmediate(clone.transform.GetChild(0).gameObject);   // usuwanie wszystkich obiektów przypisanych do prefaba, jest to końieczne, ponieważ prefab tworzy samego siebie
            }
//            clone.GetComponent<LevelGenerator>().GenerateLevel();
            clone.name = "sektor";
            clone.GetComponent<NextMap>().CheckNeighbors();
        }
        if (player.transform.position.z < transform.position.z - mapHeight / 2 + offset + camHeight / 2 &&
            player.transform.position.z > transform.position.z - mapHeight &&
            player.transform.position.x > transform.position.x - mapWidth / 2 + offset - camWidth / 2 &&
            player.transform.position.x < transform.position.x + mapWidth / 2 - offset + camWidth / 2 &&
            bottom == false)
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - mapHeight);
            GameObject clone = Instantiate(map, newPos, Quaternion.identity, transform.parent);
            while (clone.transform.childCount != 0)
            {
                DestroyImmediate(clone.transform.GetChild(0).gameObject);
            }
//            clone.GetComponent<LevelGenerator>().GenerateLevel();
            clone.name = "sektor";
            clone.GetComponent<NextMap>().CheckNeighbors();
        }
        if (player.transform.position.x < transform.position.x - mapWidth / 2 + offset + camWidth / 2 &&
            player.transform.position.x > transform.position.x - mapWidth &&
            player.transform.position.z < transform.position.z + mapHeight / 2 - offset + camHeight / 2 &&
            player.transform.position.z > transform.position.z - mapHeight / 2 + offset - camHeight / 2 &&
            left == false)
        {
            Vector3 newPos = new Vector3(transform.position.x - mapWidth, transform.position.y, transform.position.z);
            GameObject clone = Instantiate(map, newPos, Quaternion.identity, transform.parent);
            while (clone.transform.childCount != 0)
            {
                DestroyImmediate(clone.transform.GetChild(0).gameObject);
            }
//            clone.GetComponent<LevelGenerator>().GenerateLevel();
            clone.name = "sektor";
            clone.GetComponent<NextMap>().CheckNeighbors();
        }
        if (player.transform.position.x > transform.position.x + mapWidth / 2 - offset - camWidth / 2 &&
            player.transform.position.x < transform.position.x + mapWidth &&
            player.transform.position.z < transform.position.z + mapHeight / 2 - offset + camHeight / 2 &&
            player.transform.position.z > transform.position.z - mapHeight / 2 + offset - camHeight / 2 &&
            right == false)
        {
            Vector3 newPos = new Vector3(transform.position.x + mapWidth, transform.position.y, transform.position.z);
            GameObject clone = Instantiate(map, newPos, Quaternion.identity, transform.parent);
            while (clone.transform.childCount != 0)
            {
                DestroyImmediate(clone.transform.GetChild(0).gameObject);
            }
//            clone.GetComponent<LevelGenerator>().GenerateLevel();
            clone.name = "sektor";
            clone.GetComponent<NextMap>().CheckNeighbors();
        }
    }

    // funkcja usuwa dany sektor jeśli znajduję się za daleko od gracza w celu optymalizacji 
    private void DestroySector()
    {
        // potrzebne najpierw jest zmiana wartości boolowskich o tym czy dany sektor ma sąsiada, we wszystkich sąsiadach tego sektoru(przeciwięństwo CheckNeighbors())
        for (int i = 0; i < transform.parent.transform.childCount; i++) // wykonaj dla każdego sektora
        {
            Debug.Log(i + " " + transform.parent.transform.childCount);
            Vector3 childPos = transform.parent.transform.GetChild(i).transform.position;
            if (childPos.z == transform.position.z + mapHeight && childPos.x == transform.position.x)
            {
                transform.parent.transform.GetChild(i).GetComponent<NextMap>().bottom = false;
            }
            else if (childPos.z == transform.position.z - mapHeight && childPos.x == transform.position.x)
            {
                transform.parent.transform.GetChild(i).GetComponent<NextMap>().top = false;
            }
            else if (childPos.x == transform.position.x + mapWidth && childPos.z == transform.position.z)
            {
                transform.parent.transform.GetChild(i).GetComponent<NextMap>().left = false;
            }
            else if (childPos.x == transform.position.x - mapWidth && childPos.z == transform.position.z)
            {
                transform.parent.transform.GetChild(i).GetComponent<NextMap>().right = false;
            }
        }
        Destroy(gameObject);
    }
}
