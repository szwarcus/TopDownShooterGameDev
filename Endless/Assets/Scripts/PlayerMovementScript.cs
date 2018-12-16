﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
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
    void Start()
    {
        speed = BM.playerSpeed;         // wczytanie prędkości z menagera balansu
        transform.position = new Vector3(0, 2, 0);

    }

    // Funkcja pozwala na przemieszczenie gracza w zadanym kierunku
    public void Move(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    //float angle360(Vector3 from, Vector3 to, Vector3 right)
    //{
    //    float angle = Vector3.Angle(from, to);
    //    return (Vector3.Angle(right, to) > 90f) ? 360f - angle : angle;
    //}
    //public void Rotate()
    //{
    //    Vector3 mousePos = Input.mousePosition;
    //    Vector3 direction= Camera.main.ScreenToWorldPoint(mousePos);
    //    Debug.Log(direction);
    //    float angle = angle360(direction, transform.position,Vector3.up) ;
    //    float radians = Mathf.Deg2Rad*angle;
    //    Quaternion rotation = Quaternion.Euler(0, angle, 0);

    //    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    //}

    public void Rotate()
    {
        Camera camera = FindObjectOfType<Camera>();
        Ray cameraRay = camera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }




}