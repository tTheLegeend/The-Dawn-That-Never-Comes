using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttack : MonoBehaviour
{
    




    public Rigidbody2D rb;
    public Transform gun;
   
    public Camera cam;
    public Vector2 mousePos;


    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
       

    }
    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        gun.eulerAngles = new Vector3(0, 0, angle);
    }

  
}
