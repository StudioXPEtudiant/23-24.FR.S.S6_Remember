using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item", order = 0)]
public class Item : ScriptableObject
{
    public string itemName; // Nom de l'objet
    public Sprite icon; // Icône de l'objet
    public string description; // Description de l'objet
    public ItemType itemType; // Type de l'objet (équipement, consommable, etc...) 
    public int maxStackSize = 5;  // Taille maximale de la pile pour les objets stackable
}

public enum ItemType
{
    Weapon,
    Armor,
    Consumable,
    Misc
}

