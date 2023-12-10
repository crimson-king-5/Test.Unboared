using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickUpObject : MonoBehaviour, IpickUpObject
{
    [SerializeField] private int healtAmount;
    
    public void OnpickUp(Character character)
    {
        character.Heal(healtAmount);
    }
}
