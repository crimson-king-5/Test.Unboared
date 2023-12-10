using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour, IpickUpObject
{
    [SerializeField] private int count;
    public void OnpickUp(Character character)
    {
        character.coins.Add(count);
    }
}
