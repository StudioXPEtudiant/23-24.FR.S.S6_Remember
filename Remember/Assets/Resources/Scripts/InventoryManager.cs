using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<Item> inventoryItems = new List<Item>(); // Liste d'objets dans l'inventaire
    public Transform slotsParent; // Référence à l'objet contenant les slots
    private InventorySlot[] slots;

    public int inventorySize = 54;

    void Start()
    {
        slots = slotsParent.GetComponentsInChildren<InventorySlot>();
        UpdateInventoryUI();
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddItem(Item newItem)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetItem() == null)
            {
                slots[i].SetItem(newItem);
                inventoryItems.Add(newItem);
                return;
            }
        }
    }

    public void RemoveItem(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetItem() == item)
            {
                slots[i].ClearSlot();
                inventoryItems.Remove(item);
                return;
            }
        }
    }

    public void UpdateInventoryUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventoryItems.Count)
            {
                slots[i].SetItem(inventoryItems[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
