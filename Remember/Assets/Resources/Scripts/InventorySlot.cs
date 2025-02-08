using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon; // Référence à l'icône dans le slot
    private Item currentItem; // L'objet contenu dans ce slot (ScriptableObject)

    public void SetItem(Item item)
    {
        currentItem = item;
        if(item != null )
        {
            icon.sprite = item.icon;
            icon.enabled = true;
        }
        else
        {
            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        currentItem = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void OnSlotClicked()
    {
        Debug.Log("Slot cliqué !");
        if ( currentItem != null )
        {
            InventoryUI.Instance.DisplayItemDetails(currentItem);
        }
        else
        {
            Debug.LogWarning("Aucun objet dans ce slot !");
        }
    }

    public Item GetItem() => currentItem;
}
