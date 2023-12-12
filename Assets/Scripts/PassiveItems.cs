using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    private Character character;
    [SerializeField] private List<Item> items;
    


    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Start()
    {
       
    }

    public void Equip(Item itemToEquip)
    {
        if (items == null)
        {
            items = new List<Item>();
        }

        Item newItemInstance = new Item();
        newItemInstance.Init(itemToEquip.Name);
        newItemInstance.Stats.Sum(itemToEquip.Stats);
       
        
        
        items.Add(newItemInstance);
        newItemInstance.Equip(character);
    }

    public void UnEquip(Item itemToUnEquip)
    {
        
    }

    internal void UpgradeItem(UpgradeData upgradeData)
    {
        Item itemToUpgrade = items.Find(id => id.Name == upgradeData.item.Name);
        itemToUpgrade.UnEquip(character);
        itemToUpgrade.Stats.Sum(upgradeData.itemStats);
        itemToUpgrade.Equip(character);
    }
}
