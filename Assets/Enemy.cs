using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private Transform targetDestination;
   [SerializeField] private float speed;
   private GameObject targetGameobject;
   
   private Rigidbody2D rb2d;
   [SerializeField] private int hp = 4;
   private void Awake()
   {
      rb2d = GetComponent<Rigidbody2D>();
      targetGameobject = targetDestination.gameObject;
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

   public void TakeDamage(int damage)
   {
      hp -= damage;
      if (hp < 1)
      {
         Destroy(gameObject);
      }
   }
   
   private void Attack()
   {
    // Debug.Log("Attacking player");
   }
}
