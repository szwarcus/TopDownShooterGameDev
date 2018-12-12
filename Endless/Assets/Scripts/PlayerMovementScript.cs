using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {
    /*
     * Skrypt opisuje poruszanie się postaci gracza.
     */

    private BalanceMenager BM;

    private float speed;

    private void Awake()
    {
        BM = GameObject.FindGameObjectWithTag("GM").GetComponent<BalanceMenager>();
        if (BM == null)
            Debug.LogError("PlayerMovementScript: BalanceMenager not found!");
    }
    // Use this for initialization
    void Start () {
        speed = BM.playerSpeed;         // wczytanie prędkości z menagera balansu
        transform.position = new Vector3(0,2,0);
	}

    // Funkcja pozwala na przemieszczenie gracza w zadanym kierunku
    public void Move(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime); 
    }

}
