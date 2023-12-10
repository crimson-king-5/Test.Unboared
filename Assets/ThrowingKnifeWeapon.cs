using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnifeWeapon : MonoBehaviour
{
   [SerializeField] private float timeToAttack; 
   [SerializeField] private GameObject knifePrefab;
   private float timer;
   private PlayerMovement playerMove;

   private void Awake()
   {
      playerMove = GetComponent<PlayerMovement>();
   }

   private void Update()
   {
      if (timer < timeToAttack)
      {
         timer += Time.deltaTime;
         return;
      }

      timer = 0;
      SpawnKnife();
   }

   // ReSharper disable Unity.PerformanceAnalysis
   private void SpawnKnife()
   {
      GameObject throwKnife = Instantiate(knifePrefab);
      throwKnife.transform.position = transform.position;
      throwKnife.GetComponent<ThrowingKnifeProjectile>().SetDirection(playerMove.lastHorizontalVector,0f);
   }
}
