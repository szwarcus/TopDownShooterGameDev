using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour {
    /*
     * TODO: - dodaæ mo¿liwoœc manipuolwania czêstotliwoœci¹ wystêpowania œcian i przeciwników
     *       - dodaæ obiekty specjalne (np. skrzynie)
     *       
     * Skrypt pozwala na losow¹ generacjê sektora planszy. Plansza sk³ada siê z pustych pól, œcian i przeciwników
     */
    [SerializeField]
    private bool startingLevel = false;             // pozwala na wygenerowanie sektora startowego zawieraj¹cego tylko œciany (bez przeciwników i obiektów specjalnych)
    private GameObject player;

    private NavMeshSurface navMeshSurface;

	public int width = 10;
	public int height = 10;

    [SerializeField]
	private GameObject wall;
    [SerializeField]
	private GameObject zombie;

    // przypisanie referencji
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            Debug.LogError("LevelGenerator: no player found!");
        navMeshSurface = player.transform.GetComponentInChildren<NavMeshSurface>();
        if (navMeshSurface == null)
            Debug.LogError("LevelGenerator: no nav mash agent found!");
    }
    // Use this for initialization
    void Start () {
        if (startingLevel == true)
            GenerateLevel();
    }
	
	// Create a grid based level
	public void GenerateLevel()
	{
//        Debug.Log(transform.childCount);
        // Loop over the grid
        for (int x = 0; x <= width; x+=2)
		{
			for (int y = 0; y <= height; y+=2)
			{
                if(startingLevel == true)// Should we generate starting level?
                {
                    if (Random.value > .8f && ((x < width / 2 - 2 || x > width / 2 + 2) && (y < height / 2 - 2 || y > height / 2 + 2)))// Should we place a wall?
                    {
                        // Spawn a wall
                        Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
                        Instantiate(wall, pos, Quaternion.identity, transform);
                    }
                }
                else
                {
                    if (Random.value > .8f)// Should we place a wall?
                    {
                        // Spawn a wall
                        Vector3 pos = new Vector3(x - width / 2f + transform.position.x, 1f, y - height / 2f + transform.position.z);
                        Instantiate(wall, pos, Quaternion.identity, transform);
                    }
                    else if (Random.value > .9f) // Should we spawn a zombie?
                    {
                        // Spawn the zombie
                        Vector3 pos = new Vector3(x - width / 2f + transform.position.x, 1.25f, y - height / 2f + transform.position.z);
                        //Instantiate(zombie, pos, Quaternion.identity);
                    }
                }
            }
		}
        navMeshSurface.BuildNavMesh();
//        Debug.Log(transform.childCount);
    }
}
