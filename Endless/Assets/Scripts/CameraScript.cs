using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraScript : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(player.transform.position.x, 10, player.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 cameraPosition = new Vector3(player.transform.position.x, 10, player.transform.position.z);
        transform.position = cameraPosition;
    }
}
