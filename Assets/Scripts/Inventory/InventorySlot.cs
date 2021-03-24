using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public InventoryItem currentItem;
    public bool weaponSlot = false;
    public bool healSlot = false;
    public bool isFull = false;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            InventoryItem newItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            InventorySlot OriginalSlot = newItem.originalSlot.GetComponent<InventorySlot>();

            // Original Slot != This Slot //
            if (newItem.originalSlot != this.transform)
            {
                // Slot == Full //
                if (isFull)
                {
                    // Dragging Into Weapon Slot From Normal Slot
                    if (weaponSlot && newItem.equipType == 1 && OriginalSlot.currentItem.equipType == 1)
                    {
                        Debug.Log("Dropped Item: Full Weapon Slot");

                        // Swapping InventoryItem:currentItem 
                        InventoryItem swapCurrent = currentItem;
                        currentItem = newItem;
                        OriginalSlot.currentItem = swapCurrent;

                        // Swapping InventoryItem:inWeaponSlot
                        currentItem.inWeaponSlot = true;
                        OriginalSlot.currentItem.inWeaponSlot = false;

                        // Swapping Parent
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        OriginalSlot.currentItem.transform.SetParent(OriginalSlot.transform);
                        OriginalSlot.currentItem.originalSlot = OriginalSlot.transform;

                        // Spawning Weapon
                        GameManager.Instance.weaponID = currentItem.itemID;
                        GameManager.Instance.SpawnWeapon();
                    }
                    // Dragging Into Heal Slot From Normal Slot
                    else if (healSlot && newItem.equipType == 2 && OriginalSlot.currentItem.equipType == 2)
                    {
                        Debug.Log("Dropped Item: Full Heal Slot");

                        // Swapping InventoryItem:currentItem 
                        InventoryItem swapCurrent = currentItem;
                        currentItem = newItem;
                        OriginalSlot.currentItem = swapCurrent;

                        // Swapping InventoryItem:inHealSlot
                        currentItem.inHealSlot = false;
                        OriginalSlot.currentItem.inHealSlot = true;

                        // Swapping Parent
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        OriginalSlot.currentItem.transform.SetParent(OriginalSlot.transform);
                        OriginalSlot.currentItem.originalSlot = OriginalSlot.transform;

                        // Spawning Heal
                        GameManager.Instance.healID = OriginalSlot.currentItem.itemID;
                        GameManager.Instance.SpawnHeal();
                    }
                    // Dragging Into Normal Slot From Weapon Slot
                    else if (!weaponSlot && currentItem.equipType == 1 && newItem.equipType == 1 && newItem.inWeaponSlot)
                    {
                        Debug.Log("Dropped Item: Full Weapon Slot [Other]");

                        // Swapping InventoryItem:currentItem 
                        InventoryItem swapCurrent = currentItem;
                        currentItem = newItem;
                        OriginalSlot.currentItem = swapCurrent;

                        // Swapping InventoryItem:inWeaponSlot
                        currentItem.inWeaponSlot = false;
                        OriginalSlot.currentItem.inWeaponSlot = true;

                        // Swapping Parent
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        OriginalSlot.currentItem.transform.SetParent(OriginalSlot.transform);
                        OriginalSlot.currentItem.originalSlot = OriginalSlot.transform;

                        // Spawning Weapon
                        GameManager.Instance.weaponID = OriginalSlot.currentItem.itemID;
                        GameManager.Instance.SpawnWeapon();
                    }
                    // Dragging Into Normal Slot From Heal Slot
                    else if (!healSlot && currentItem.equipType == 2 && newItem.equipType == 2 && newItem.inHealSlot)
                    {
                        Debug.Log("Dropped Item: Full Heal Slot [Other]");

                        // Swapping InventoryItem:currentItem 
                        InventoryItem swapCurrent = currentItem;
                        currentItem = newItem;
                        OriginalSlot.currentItem = swapCurrent;

                        // Swapping InventoryItem:inHealSlot
                        currentItem.inHealSlot = false;
                        OriginalSlot.currentItem.inHealSlot = true;

                        // Swapping Parent
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        OriginalSlot.currentItem.transform.SetParent(OriginalSlot.transform);
                        OriginalSlot.currentItem.originalSlot = OriginalSlot.transform;

                        // Spawning Heal
                        GameManager.Instance.healID = OriginalSlot.currentItem.itemID;
                        GameManager.Instance.SpawnHeal();
                    }
                    // Slot Swapping In Inventory
                    else if (!OriginalSlot.currentItem.inHealSlot && !OriginalSlot.currentItem.inWeaponSlot && !currentItem.inWeaponSlot && !currentItem.inHealSlot)
                    {
                        Debug.Log("Dropped Item: Full Inventory Slot");

                        // Swapping InventoryItem:currentItem 
                        InventoryItem swapCurrent = currentItem;
                        currentItem = newItem;
                        OriginalSlot.currentItem = swapCurrent;

                        // Swapping Parent
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        OriginalSlot.currentItem.transform.SetParent(OriginalSlot.transform);
                        OriginalSlot.currentItem.originalSlot = OriginalSlot.transform;
                    }
                    // Returning To Original Slot
                    else
                    {
                        Debug.Log("Dropped Item: Returning to original slot");
                    }
                }
                // Slot != Full //
                else if (!isFull)
                {
                    // Moving Into Weapon Slot
                    if (weaponSlot && newItem.equipType == 1)
                    {
                        Debug.Log("Dropped Item: Empty Weapon Slot");

                        // Emptying Original Slot
                        OriginalSlot.isFull = false;
                        OriginalSlot.currentItem = null;

                        // Filling This Slot
                        isFull = true;
                        currentItem = newItem;
                        currentItem.inWeaponSlot = true;

                        // Swapping Parents
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        currentItem.originalSlot = this.transform;

                        // Spawning Weapon
                        GameManager.Instance.weaponID = currentItem.itemID;
                        GameManager.Instance.SpawnWeapon();
                    }
                    // Moving Into Heal Slot
                    else if (healSlot && newItem.equipType == 2)
                    {
                        Debug.Log("Dropped Item: Empty Heal Slot");

                        // Emptying Original Slot
                        OriginalSlot.isFull = false;
                        OriginalSlot.currentItem = null;

                        // Filling This Slot
                        isFull = true;
                        currentItem = newItem;
                        currentItem.inHealSlot = true;

                        // Swapping Parents
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        currentItem.originalSlot = this.transform;

                        // Spawning Heal
                        GameManager.Instance.healID = currentItem.itemID;
                        GameManager.Instance.SpawnHeal();

                    }
                    // Moving Out Of Weapon Slot
                    else if (OriginalSlot.weaponSlot == true && newItem.inWeaponSlot == true && !healSlot)
                    {
                        Debug.Log("Dropped Item: Empty Inventory Slot");

                        // Emptying Original Slot
                        OriginalSlot.isFull = false;
                        OriginalSlot.currentItem = null;

                        // Filling This Slot
                        isFull = true;
                        currentItem = newItem;
                        currentItem.inWeaponSlot = false;

                        // Swapping Parents
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        currentItem.originalSlot = this.transform;

                        // Destroying Weapon
                        GameManager.Instance.weaponID = -1;
                        GameManager.Instance.DestroyWeapon();
                    }
                    // Moving Out Of Heal Slot
                    else if (OriginalSlot.healSlot == true && newItem.inHealSlot == true && !weaponSlot)
                    {
                        Debug.Log("Dropped Item: Empty Inventory Slot");

                        // Emptying Original Slot
                        OriginalSlot.isFull = false;
                        OriginalSlot.currentItem = null;

                        // Filling This Slot
                        isFull = true;
                        currentItem = newItem;
                        currentItem.inHealSlot = false;

                        // Swapping Parents
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        currentItem.originalSlot = this.transform;

                        // Destroying Weapon
                        GameManager.Instance.healID = -1;
                        GameManager.Instance.DestroyHeal();
                    }
                    // Moving To Empty Slot
                    else if (!OriginalSlot.healSlot && !healSlot && !OriginalSlot.weaponSlot && !weaponSlot)
                    {
                        // Emptying Original Slot
                        OriginalSlot.isFull = false;
                        OriginalSlot.currentItem = null;

                        // Filling This Slot
                        isFull = true;
                        currentItem = newItem;

                        // Swapping Parents
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        currentItem.originalSlot = this.transform;
                    }
                    // Returning to Original Slot
                    else
                    {
                        Debug.Log("Dropped Item: Returning to original slot");
                    }
                }
            }
        }
    }
}
