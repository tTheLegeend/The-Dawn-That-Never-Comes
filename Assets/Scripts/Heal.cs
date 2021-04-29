using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int hp;
    private GameObject player;

    void Awake()
    {
        
        player = GameObject.Find("Player");
        

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
           if (player.GetComponent<PlayerMovement>().health < 100)
            {
                AddHP();
            }
           else
            {
                Debug.Log("already full");
            }
        }
    }

    public void AddHP()
    {
        player.GetComponent<PlayerMovement>().setHealth(hp);
        Destroy(gameObject);
    }
}

