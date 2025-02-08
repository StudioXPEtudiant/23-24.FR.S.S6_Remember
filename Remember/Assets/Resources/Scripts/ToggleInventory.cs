using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    public GameObject inventoryUI; // Référence au GameObject de l'inventaire (le parent)

    public bool isInventoryOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // Appuie sur I pour ouvrir/fermer
        {
            isInventoryOpen = !isInventoryOpen;
            inventoryUI.SetActive(isInventoryOpen);
        }
    }
}
