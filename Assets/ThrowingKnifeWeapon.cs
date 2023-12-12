using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnifeWeapon : WeaponBase
{
   
   [SerializeField] private GameObject knifePrefab;
   [SerializeField] private float spread = 0.5f;
   private PlayerMovement playerMove;

   private void Awake()
   {
      playerMove = GetComponent<PlayerMovement>();
   }
   
   public override void Attack()
   {
      

      for (int i = 0; i < weaponStats.numberOfAttacks; i++)
      {
         GameObject throwKnife = Instantiate(knifePrefab);

         Vector3 newKnifePosition = transform.position;
         if (weaponStats.numberOfAttacks > 1)
         {
            newKnifePosition.y -= (spread * (weaponStats.numberOfAttacks -1)) / 2;
            newKnifePosition.y += i * spread;
         }
         

         throwKnife.transform.position = newKnifePosition;
         
         ThrowingKnifeProjectile throwingKnifeProjectile = throwKnife.GetComponent<ThrowingKnifeProjectile>();
         throwingKnifeProjectile.SetDirection(
            playerMove.lastHorizontalVector,
            0f);
         throwingKnifeProjectile.damage = weaponStats.damage;
      }
      
    
   }
   
}
