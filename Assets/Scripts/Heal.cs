using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int hp;
    private GameObject player;
    private GameObject gameHealSlot;
    private Transform gameHealItem;
    void Awake()
    {
        
        player = GameObject.Find("Player");
        gameHealSlot = GameObject.Find("Heal Slot");
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
        gameHealItem = gameHealSlot.transform.GetChild(0);
        InventorySlot healSlot = GameManager.Instance.inventorySlots[1];
        InventoryItem healItem = GameManager.Instance.inventorySlots[1].currentItem;
        healSlot.currentItem = null;
        healSlot.isFull = false;
        GameManager.Instance.healID = -1;
        GameManager.Instance.DestroyHeal();
        Destroy(gameHealItem.gameObject);
        Destroy(healItem);

    }
}

