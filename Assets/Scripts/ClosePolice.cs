using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePolice : MonoBehaviour
{
    public GameObject doorOpen;
       

    // Start is called before the first frame update
    void Start()
    {
        doorOpen.SetActive(false);
    }

}
