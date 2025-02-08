using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [Header("UI Elements")]
    public Text itemNameText;
    public Text itemDescriptionText;
    public Image itemIconImage;
    public Text itemTypeText;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void DisplayItemDetails(Item item)
    {
        itemNameText.text = item.itemName;
        itemDescriptionText.text = item.description;
        itemIconImage.sprite = item.icon;
        itemIconImage.enabled = true;
        itemTypeText.text = item.itemType.ToString();
    }

    public void ClearItemDetails()
    {
        itemNameText.text = "";
        itemDescriptionText.text = "";
        itemIconImage.enabled = false;
        itemTypeText.text = "";
    }
}
