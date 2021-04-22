using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public int ammo;
    public bool isFiring;
    public Text ammoDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoDisplay.text = ammo.ToString();
        if (Input.GetMouseButtonDown(0) && !isFiring && ammo > 0)
        {
            isFiring = true;
            ammo--;
            isFiring = false; //If ammo has ran out
        }
    }
}
