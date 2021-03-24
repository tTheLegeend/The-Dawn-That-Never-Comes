using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    RectTransform rectTransform;
    public CanvasGroup canvasGroup;
    public Transform originalSlot;

    public bool inHealSlot = false;
    public bool inWeaponSlot = false;
    public int itemID;
    public int equipType = 0; // 0 = None | 1 = Weapon | 2 = Heal //

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / GameManager.Instance.interfaceCanvas.scaleFactor;
        gameObject.transform.SetParent(GameManager.Instance.draggables);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        rectTransform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        originalSlot = transform.parent.transform;
    } 
    public void OnEndDrag(PointerEventData eventData)
    {
        // Revert State //
        canvasGroup.blocksRaycasts = true;
        rectTransform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
        if (transform.parent == GameManager.Instance.draggables)
        {
            transform.SetParent(originalSlot);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && !eventData.dragging)
        {
            InventorySlot currentSlot = transform.parent.GetComponent<InventorySlot>();

            // If this item is in the weapon slot
            if (currentSlot.weaponSlot)
            {
                for (int i = 2; i < GameManager.Instance.inventorySlots.Length; i++)
                {
                    Debug.Log("Searching for Slot...");
                    if (GameManager.Instance.inventorySlots[i].isFull == false)
                    {
                        Debug.Log("Found slot: " + GameManager.Instance.inventorySlots[i].name);

                        // Emptying Previous Slot
                        currentSlot.isFull = false;
                        currentSlot.currentItem = null;

                        // Occupying New Slot
                        GameManager.Instance.inventorySlots[i].currentItem = this;
                        GameManager.Instance.inventorySlots[i].isFull = true;

                        // Changing 
                        inWeaponSlot = false;
                        transform.SetParent(GameManager.Instance.inventorySlots[i].transform);
                        GameManager.Instance.DestroyWeapon();

                        break;
                    }
                }
            }
            // If this item is in the heal slot
            if (currentSlot.healSlot)
            {
                for (int i = 2; i < GameManager.Instance.inventorySlots.Length; i++)
                {
                    Debug.Log("Searching for Slot...");
                    if (GameManager.Instance.inventorySlots[i].isFull == false)
                    {
                        Debug.Log("Found slot: " + GameManager.Instance.inventorySlots[i].name);

                        // Emptying Previous Slot
                        currentSlot.isFull = false;
                        currentSlot.currentItem = null;

                        // Occupying New Slot
                        GameManager.Instance.inventorySlots[i].currentItem = this;
                        GameManager.Instance.inventorySlots[i].isFull = true;

                        // Changing 
                        inHealSlot = false;
                        transform.SetParent(GameManager.Instance.inventorySlots[i].transform);
                        GameManager.Instance.DestroyHeal();

                        break;
                    }
                }
            }
            // If this item is NOT in the weapon slot and Equip Type == Weapon
            else if (!currentSlot.weaponSlot && equipType == 1)
            {
                if (GameManager.Instance.inventorySlots[0].isFull)
                {
                    // Setting Inventory Slot
                    currentSlot.currentItem = GameManager.Instance.inventorySlots[0].currentItem;
                    currentSlot.currentItem.inWeaponSlot = false;
                    currentSlot.currentItem.gameObject.transform.SetParent(currentSlot.transform);

                    // Setting Weapon Slot
                    GameManager.Instance.inventorySlots[0].currentItem = this;
                    inWeaponSlot = true;
                    gameObject.transform.SetParent(GameManager.Instance.inventorySlots[0].transform);
                    GameManager.Instance.weaponID = itemID;
                    GameManager.Instance.SpawnWeapon();
                } 
                else
                {
                    // Resetting Old Slot
                    currentSlot.currentItem = null;
                    currentSlot.isFull = false;

                    // Setting Weapon Slot
                    GameManager.Instance.inventorySlots[0].currentItem = this;
                    GameManager.Instance.inventorySlots[0].isFull = true;
                    inWeaponSlot = true;
                    gameObject.transform.SetParent(GameManager.Instance.inventorySlots[0].transform);
                    GameManager.Instance.weaponID = itemID;
                    GameManager.Instance.SpawnWeapon();
                }
            }
            // If this item is NOT in the heal slot and Equip Type == Heal
            else if (!currentSlot.healSlot && equipType == 2)
            {
                if (GameManager.Instance.inventorySlots[1].isFull)
                {
                    // Setting Inventory Slot
                    currentSlot.currentItem = GameManager.Instance.inventorySlots[1].currentItem;
                    currentSlot.currentItem.inHealSlot = false;
                    currentSlot.currentItem.gameObject.transform.SetParent(currentSlot.transform);

                    // Setting Weapon Slot
                    GameManager.Instance.inventorySlots[1].currentItem = this;
                    inHealSlot = true;
                    transform.SetParent(GameManager.Instance.inventorySlots[1].transform);
                    GameManager.Instance.healID = itemID;
                    GameManager.Instance.SpawnHeal();
                }
                else
                {
                    // Resetting Old Slot
                    currentSlot.currentItem = null;
                    currentSlot.isFull = false;

                    // Setting Weapon Slot
                    GameManager.Instance.inventorySlots[1].currentItem = this;
                    GameManager.Instance.inventorySlots[1].isFull = true;
                    inHealSlot = true;
                    gameObject.transform.SetParent(GameManager.Instance.inventorySlots[1].transform);
                    GameManager.Instance.healID = itemID;
                    GameManager.Instance.SpawnHeal();
                }
            }
        }
    }
}
