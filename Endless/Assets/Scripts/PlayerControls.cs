using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    /*
     * Skryp pozwala na odczytywanie sygnałów wejściowych na klawiturę i myszkę.
     * 
     */

    private PlayerMovementScript movementScript;
    public GunControler gun;
    private Vector3 direction = new Vector3();

    private void Awake()
    {
        movementScript = transform.GetComponent<PlayerMovementScript>();
        if (movementScript == null)
            Debug.LogError("PlayerControls: player movement script not found!");
        gun.choosedWeapon = gun.we1.weapon[0];
    }

    void Update()
    {
        GetInput();
        movementScript.Move(direction);             // Wykonaj ruch w zadanym kierunku
        movementScript.Rotate();
    }

    // Odczytanie wejść
    private void GetInput()
    {
        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += new Vector3(1, 0, 0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            gun.isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            gun.isFiring = false;
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            gun.choosedWeapon = gun.we1.weapon[0];
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            gun.choosedWeapon = gun.we1.weapon[1];
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            gun.choosedWeapon = gun.we1.weapon[2];
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            gun.choosedWeapon = gun.we1.weapon[3];
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            gun.choosedWeapon = gun.we1.weapon[4];
        }
        if (Input.GetKey(KeyCode.R))
        {
            gun.Reload();
        }
    }
}
