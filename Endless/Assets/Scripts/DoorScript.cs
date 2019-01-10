using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet" || collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
