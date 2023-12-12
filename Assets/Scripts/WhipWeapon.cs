using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WhipWeapon : WeaponBase
{
    
    [SerializeField] private GameObject leftWhipObject;
    [SerializeField] private GameObject rightWhipObject;
    private PlayerMovement playerMove;
    [FormerlySerializedAs("whipAttackSize")] [SerializeField] Vector2 attackSize = new Vector2(4f, 2f);
   
    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame

   
    // ReSharper disable Unity.PerformanceAnalysis
    public override void Attack()
    {
        if (playerMove.lastHorizontalVector > 0)
        {
            rightWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            leftWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }
       
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamageable e = colliders[i].GetComponent<IDamageable>();
            if (e != null)
            {
                PostDamage(weaponStats.damage, colliders[i].transform.position);
               e.TakeDamage(weaponStats.damage);
            }
           
        }
    }
}
