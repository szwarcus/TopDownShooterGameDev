using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMap : MonoBehaviour {
    /*
     * TODO: - Poprawić sprawdzanie kidy generować nowy sektor zależnie od pozycji gracza (aktualnie nowy sektor tworzy się jeśli gracz zbiży się do krawędzi np. jak idzie w prawo to WSZYSTKIE sektory które nie mają z prawej strony sąsiada generyją jednego a nie tylko ten przy którym jest gracz)
     *       - Dodać usuwanie sektoró w zależności od odległości między sektorem a graczem
     *       - Uzależnić generowanie od wielkości ekranu (na razie jest tylko offset)
     * Skrypt służy do generacji nowego sektora mapy oraz usuwania jeśli znajduje się w znacznej odległości od gracza.
     */

    public bool top = false, bottom = false, left = false, right = false;
    private float width, height;

    [SerializeField]
    private float offset = 16f;

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
        width = transform.GetComponent<LevelGenerator>().width;
        height = transform.GetComponent<LevelGenerator>().height;
    }
	// Update is called once per frame
	void Update () {
        CheckNewMap();
    }

    // Funkcja pozwala na sprawdzenie czy któryś z istniejących sektorów jest sąsiadem tego sektora (sąsiad rozumiany poprzez 4 kierunki góra, dół, lewo i prawo ale nie na ukos)
    public void CheckNeighbors()
    {
        for(int i = 0; i < map.transform.parent.transform.childCount; i++) // wykonaj dla każdego sektora
        {
            Vector3 childPos = map.transform.parent.transform.GetChild(i).transform.position;
            if(childPos.z == transform.position.z + height && childPos.x == transform.position.x)
            {
//                Debug.Log("Sąsiad u góry");
                top = true;
                map.transform.parent.transform.GetChild(i).GetComponent<NextMap>().bottom = true;
            }
            else if (childPos.z == transform.position.z - height && childPos.x == transform.position.x)
            {
//                Debug.Log("Sąsiad na dole");
                bottom = true;
                map.transform.parent.transform.GetChild(i).GetComponent<NextMap>().top = true;
            }
            else if (childPos.x == transform.position.x + width && childPos.z == transform.position.z)
            {
//                Debug.Log("Sąsiad na prawo");
                right = true;
                map.transform.parent.transform.GetChild(i).GetComponent<NextMap>().left = true;
            }
            else if (childPos.x == transform.position.x - width && childPos.z == transform.position.z)
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
        float topDistance = transform.position.z - player.transform.position.z + height / 2;
        float bottomDistance = -transform.position.z + player.transform.position.z + height / 2;
        
        
        float rightDistance = transform.position.x - player.transform.position.x + width / 2;
        float leftDistance = -transform.position.x + player.transform.position.x + width / 2;
        // nalezy zmianić formuły w if-ach poniżej
        if (topDistance < offset && top == false && - transform.position.x - width < player.transform.position.x)
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + height);
            GameObject clone = Instantiate(map, newPos, Quaternion.identity, transform.parent);
            while(clone.transform.childCount != 0)
            {
                DestroyImmediate(clone.transform.GetChild(0).gameObject);   // usuwanie wszystkich obiektów przypisanych do prefaba, jest to końieczne, ponieważ prefab tworzy samego siebie
            }
            clone.GetComponent<LevelGenerator>().GenerateLevel();
            clone.name = "sektor";
            clone.GetComponent<NextMap>().CheckNeighbors();
        }
        if (bottomDistance < offset && bottom == false)
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - height);
            GameObject clone = Instantiate(map, newPos, Quaternion.identity, transform.parent);
            while (clone.transform.childCount != 0)
            {
                DestroyImmediate(clone.transform.GetChild(0).gameObject);
            }
            clone.GetComponent<LevelGenerator>().GenerateLevel();
            clone.name = "sektor";
            clone.GetComponent<NextMap>().CheckNeighbors();
        }
        if (leftDistance < offset && left == false)
        {
            Vector3 newPos = new Vector3(transform.position.x - width, transform.position.y, transform.position.z);
            GameObject clone = Instantiate(map, newPos, Quaternion.identity, transform.parent);
            while (clone.transform.childCount != 0)
            {
                DestroyImmediate(clone.transform.GetChild(0).gameObject);
            }
            clone.GetComponent<LevelGenerator>().GenerateLevel();
            clone.name = "sektor";
            clone.GetComponent<NextMap>().CheckNeighbors();
        }
        if (rightDistance < offset && right == false)
        {
            Vector3 newPos = new Vector3(transform.position.x + width, transform.position.y, transform.position.z);
            GameObject clone = Instantiate(map, newPos, Quaternion.identity, transform.parent);
            while (clone.transform.childCount != 0)
            {
                DestroyImmediate(clone.transform.GetChild(0).gameObject);
            }
            clone.GetComponent<LevelGenerator>().GenerateLevel();
            clone.name = "sektor";
            clone.GetComponent<NextMap>().CheckNeighbors();
        }
    }
}
