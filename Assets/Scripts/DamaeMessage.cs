using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DamaeMessage : MonoBehaviour
{ 
 [SerializeField] private float TimeToLive = 2f;
  private float ttl = 2f;

 private void OnEnable()
 {
  ttl = TimeToLive;
 }

 private void Update()
 {
  ttl -= Time.deltaTime;
  if (ttl < 0f)
  {
   gameObject.SetActive(false);
  }
 }
}
