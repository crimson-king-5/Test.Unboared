using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableOnHit : MonoBehaviour, IDamageable
{
    public void TakeDamage(int damage)
    {
        Debug.Log("GotDamaged");
        Destroy(gameObject);
    }
}
