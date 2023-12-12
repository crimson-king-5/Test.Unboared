using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageProgress : MonoBehaviour
{
   private StageTime stageTime;

   private void Awake()
   {
      stageTime = GetComponent<StageTime>();
      
   }

   [SerializeField] private float progressTimeRate = 30f;
   [SerializeField] private float progressPerSplit = 0.2f;

   public float Progress
   {
      get
      {
         return 1f + stageTime.time / progressTimeRate * progressPerSplit;
      }
   }
}
