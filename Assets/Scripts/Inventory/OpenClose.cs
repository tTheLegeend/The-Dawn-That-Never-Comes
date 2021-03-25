using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    GameObject CanvasInventory;

    // Start is called before the first frame update
    void Awake()
    {
        CanvasInventory = GameObject.Find("CanvasInventory");
    }

    // Update is called once per frame
    void Update()
    {
        if (CanvasInventory.activeSelf)
        {
            if (Input.GetKeyDown("i"))
            {
                CanvasInventory.SetActive(false);
                UnityEngine.Debug.Log("Inventory Active");
            }
        }
        else
        {
            if (Input.GetKeyDown("i"))
            {
                CanvasInventory.SetActive(true);
                UnityEngine.Debug.Log("Inventory Not Active");
            }
        }



}

    
}
