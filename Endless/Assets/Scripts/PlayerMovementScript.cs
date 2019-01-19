using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    /*
     * Skrypt opisuje poruszanie się postaci gracza.
     */

    private BalanceMenager BM;

    [SerializeField]
    private float speed;
    private float baseSpeed;

    private void Awake()
    {
        BM = GameObject.FindGameObjectWithTag("GM").GetComponent<BalanceMenager>();
        if (BM == null)
            Debug.LogError("PlayerMovementScript: BalanceMenager not found!");
    }
    // Use this for initialization
    void Start()
    {
        speed = BM.playerSpeed;         // wczytanie prędkości z menagera balansu
        transform.position = new Vector3(0, 0.5f, 0);
        baseSpeed = speed;

    }

    public void UpdateSpeed(float value)
    {
        speed = baseSpeed + value;
    }

    // Funkcja pozwala na przemieszczenie gracza w zadanym kierunku
    public void Move(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }


    public void Rotate()
    {
        Camera camera = FindObjectOfType<Camera>();
        Ray cameraRay = camera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        Transform gunTransform = transform.GetChild(0);
        float rayLength;
        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            gunTransform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }




}