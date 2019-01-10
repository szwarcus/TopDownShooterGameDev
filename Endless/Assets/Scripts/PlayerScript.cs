using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour {

    /*
     * Skrypt przypisuje do obiektu gracza, obiekty: nawMesh, ground, mainCamera w relacji (rodzic - dziecko) 
     */

    private GameObject navMesh;
    Vector3 pos;

    private void Awake()
    {
        navMesh = GameObject.FindGameObjectWithTag("NavMesh");
        if (navMesh == null)
            Debug.LogError("PlayerScript: NavMesh not found!");

//        GameObject.FindGameObjectWithTag("Ground").transform.parent = transform;
 //       GameObject.FindGameObjectWithTag("Ground").transform.position = new Vector3(transform.position.x, - 1.4f, transform.position.z);
//        navMesh.transform.parent = transform;
//        navMesh.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        navMesh.GetComponent<NavMeshSurface>().BuildNavMesh();
        //GameObject.FindGameObjectWithTag("MainCamera").transform.parent = transform;
        pos = transform.position;
    }

    private void Update()
    {
        if(pos.x + 45 <= transform.position.x || pos.x - 45 >= transform.position.x || pos.z + 45 <= transform.position.z || pos.z - 45 >= transform.position.z)
        {
            GameObject.FindGameObjectWithTag("Ground").transform.position = new Vector3(transform.position.x, GameObject.FindGameObjectWithTag("Ground").transform.position.y, transform.position.z);
            navMesh.GetComponent<NavMeshSurface>().BuildNavMesh();
            pos = transform.position;
            Debug.Log("change pos");
        }
    }
}
