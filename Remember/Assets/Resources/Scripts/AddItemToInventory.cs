using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemToInventory : MonoBehaviour
{
    public Item testItem; // R�f�rence � ton ScriptableObject (objet � ajouter au test)

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) // Change KeyCode.A � la touche que tu pr�f�res
        {
            if (testItem != null)
            {
                InventoryManager.Instance.AddItem(testItem);
                Debug.Log($"{testItem.itemName} ajout� � l'inventaire !");
            }
            else
            {
                Debug.LogWarning("Aucun objet n'est assign� � testItem !");
            }
        }
    }
}
