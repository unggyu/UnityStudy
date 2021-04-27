﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController2 : MonoBehaviour
{
    public GameObject bulletObject;
    public Transform bulletContainer;
    public GameObject guideLine;
    
    public float ditectionRange = 4f;


    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        MouseCheck();
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            mousePos = mainCamera.ScreenToWorldPoint(mousePos);

            Vector3 playerPos = transform.position;
            
            Vector2 dirVec = mousePos - (Vector2)playerPos;
            dirVec = dirVec.normalized;

            GameObject tempObject = Instantiate(bulletObject, bulletContainer);
            tempObject.transform.right = dirVec;

            tempObject.transform.position = (Vector2)playerPos + dirVec * 0.5f;
            
            transform.Translate(-dirVec);
        }
    }

    void MouseCheck()
    {
        Vector2 mousePos = Input.mousePosition;
        mousePos = mainCamera.ScreenToWorldPoint(mousePos);

        Vector3 playerPos = transform.position;
            
        Vector2 distanceVec = mousePos - (Vector2)playerPos;
        guideLine.SetActive(distanceVec.magnitude < ditectionRange ? true : false);

        guideLine.transform.right = distanceVec.normalized;
    }
}
