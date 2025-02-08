using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemToInventory : MonoBehaviour
{
    public Item testItem; // Référence à ton ScriptableObject (objet à ajouter au test)

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) // Change KeyCode.A à la touche que tu préfères
        {
            if (testItem != null)
            {
                InventoryManager.Instance.AddItem(testItem);
                Debug.Log($"{testItem.itemName} ajouté à l'inventaire !");
            }
            else
            {
                Debug.LogWarning("Aucun objet n'est assigné à testItem !");
            }
        }
    }
}
