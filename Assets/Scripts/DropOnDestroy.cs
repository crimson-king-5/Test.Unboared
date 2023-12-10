using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropOnDestroy : MonoBehaviour
{
   [SerializeField] private GameObject healthPickUp;
   [SerializeField][Range(0f,1f)] private  float chance = 1f;
   private void OnDestroy()
   {
      if (Random.value < chance)
      {
         Transform t = Instantiate(healthPickUp).transform;
         t.position = transform.position;
      }
     
   }
}
