using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private int healAmount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character c = collision.GetComponent<Character>();
        if (c != null)
        {
            c.Heal(healAmount);
            Destroy(gameObject);
        }
    }
    
}
