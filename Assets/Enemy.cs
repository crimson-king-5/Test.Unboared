using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private Transform targetDestination;
   [SerializeField] private float speed;

   private Rigidbody2D rb2d;

   private void Awake()
   {
      rb2d = GetComponent<Rigidbody2D>();
   }

   private void FixedUpdate()
   {
      Vector3 direction = (targetDestination.position - transform.position).normalized;
      rb2d.velocity = direction * speed;
   }
}
