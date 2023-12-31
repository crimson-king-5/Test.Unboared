using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropOnDestroy : MonoBehaviour
{
   [SerializeField] List <GameObject> dropItemPrefab;
   [SerializeField][Range(0f,1f)] private  float chance = 1f;

   private bool isQuitting = false;
   private void OnApplicationQuit()
   {
      isQuitting = true;
   }

   public void CheckDrop()
   {
      if (isQuitting)
      {
         return;
      }
      if (Random.value < chance)
      {
        GameObject toDrop = dropItemPrefab[Random.Range(0, dropItemPrefab.Count)]; 
        SpawnManager.instance.SpawnObject(transform.position, toDrop);
      }
     
   }
}
