using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Weapon, Armor }

[System.Serializable]
public class Item 
{
    public string itemName;
    public ItemType type;
    public Sprite sprite;
}
