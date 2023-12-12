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
        items.Add(itemToEquip);
        itemToEquip.Equip(character);
    }

    public void UnEquip(Item itemToUnEquip)
    {
        
    }
}
