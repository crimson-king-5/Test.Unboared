using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
   [SerializeField] private GameObject healthPickUp;

   private void OnDestroy()
   {
      Transform t = Instantiate(healthPickUp).transform;
      t.position = transform.position;
   }
}
