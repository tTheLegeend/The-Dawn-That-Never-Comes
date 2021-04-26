using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class ingameEquipment
{
    public string name = "Equipment";
    public GameObject prefab;
    public GameObject inventoryItem;
    public GameObject worldItem;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int weaponID = -1;
    public int healID = -1;

    public GameObject spawnedWeapon;
    public GameObject spawnedHeal;

    public PlayerManager PM;

    public InventorySlot[] inventorySlots;
    public Canvas interfaceCanvas;
    public Transform draggables;

    public ingameEquipment[] equipment;

    // Main //
    void Awake()
    {
        GameManager.Instance = this;
    }

    public void DestroyWeapon()
    {
        if (spawnedWeapon != null)
        {
            Destroy(spawnedWeapon);
        }
    }
    public void DestroyHeal()
    {
        if (spawnedHeal != null)
        {
            Destroy(spawnedHeal);
        }
    }

    public void SpawnWeapon()
    {
        DestroyWeapon();

        if(weaponID != -1)
        {
            spawnedWeapon = Instantiate(equipment[weaponID].prefab, PM.hand);
        }
    }
    public void SpawnHeal()
    {
        DestroyHeal();

        if (healID != -1)
        {
            spawnedHeal = Instantiate(equipment[healID].prefab, PM.body);
        }
    }
    public void PickupItem(int itemID)
    {
        bool foundSlot = false;

        for (int i = 2; i < inventorySlots.Length; i++)
        {
            if (!inventorySlots[i].isFull)
            {
                GameObject GO = Instantiate(equipment[itemID].inventoryItem, inventorySlots[i].gameObject.transform);
                inventorySlots[i].currentItem = GO.GetComponent<InventoryItem>();
                inventorySlots[i].isFull = true;
                foundSlot = true;
                break;
            }
        }

        if(foundSlot == false)
        {
            Instantiate(equipment[itemID].worldItem, PM.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
    public void DropItem(InventoryItem item)
    {
        Instantiate(equipment[item.itemID].worldItem, PM.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        Destroy(item.gameObject);
    }
}
