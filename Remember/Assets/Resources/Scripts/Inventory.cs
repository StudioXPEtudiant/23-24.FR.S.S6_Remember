using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public PlayerEquipment playerEquipment;

    public void EquipItem(Item item)
    {
        if(item.type == ItemType.Weapon)
        {
            playerEquipment.EquipWeapon(item.sprite);
        }
        else if(item.type == ItemType.Armor)
        {
            playerEquipment.EquipArmor(item.sprite);
        }
    }
}
