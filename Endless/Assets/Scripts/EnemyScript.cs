using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour {
    /*
     * Skrypt pozwala na poruszanie się przeciwnika na pozycję "ofiary" (gracza) jeśli znajduje się w pewnej odległości od gracza. 
     * Do poruszania się wykorzystywany jest navMeshAgent. Jeśli przeciwnik znajduję się w znacznej odległości od gracza to navMeshAgent zostaje wyłączony.
     */
    public Transform victim;
    private NavMeshAgent meshAgent;

    // przypisanie referencji
    private void Awake()
    {
        meshAgent = transform.GetComponent<NavMeshAgent>();
        if (meshAgent == null)
            Debug.LogError("EnemyScript: no nav mash agent found!");
        
    }
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (victim) // sprawdzamy czy przeciwnik znalazł sobie cel
        {
            if (Mathf.Abs(victim.position.x - transform.position.x) < 10 && Mathf.Abs(victim.position.z - transform.position.z) < 10)   // Sprawdzamy w jakiej odległości znajduje się przeciwnik od gracza
                if(gameObject.GetComponent<NavMeshAgent>().enabled == true)
                    meshAgent.SetDestination(victim.position);
                else
                {
                    gameObject.GetComponent<NavMeshAgent>().enabled = true;
                    meshAgent.SetDestination(victim.position);
                }
            else
            {
                gameObject.GetComponent<NavMeshAgent>().enabled = false; 
            }
        }
        else
        {
            FindVictim();       // brak celu, znajdź cel
        }
	}

    // Znajduje obiekt gracza i bierze go sobie za cel
    private void FindVictim()
    {
        victim = GameObject.FindGameObjectWithTag("Player").transform;
        if (victim == null)
            Debug.LogError("EnemyScript: no victim found!");
    }
}
