using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickUpObject : MonoBehaviour, IpickUpObject
{
    [SerializeField] private int amount;
    public void OnpickUp(Character character)
    {
        character.level.AddExperience(amount);
    }
}
