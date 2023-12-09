using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
  
   [SerializeField] private float speed;
   [SerializeField]  int hp = 999;
   [SerializeField]  int damage = 1;
   private Character targetCharacter;
   private GameObject targetGameobject;
   private Transform targetDestination;
   private Rigidbody2D rb2d;
   
   private void Awake()
   {
      rb2d = GetComponent<Rigidbody2D>();
     
   }

   public void SetTarget(GameObject target)
   {
      targetGameobject = target;
      targetDestination = target.transform;



   }
   
   private void FixedUpdate()
   {
      Vector3 direction = (targetDestination.position - transform.position).normalized;
      rb2d.velocity = direction * speed;
   }

   private void OnCollisionStay2D(Collision2D collision)
   {
      if (collision.gameObject == targetGameobject ) 
      {
         Attack();
      }
   }

  
   private void Attack()
   {
      if (targetCharacter == null)
      {
         targetCharacter = targetGameobject.GetComponent<Character>();
      }
      
      targetCharacter.TamkeDamage(damage);
   }
   
   public void TakeDamage(int damage)
   {
      hp -= damage;
      if (hp < 1)
      {
         Destroy(gameObject);
      }
   }

}
