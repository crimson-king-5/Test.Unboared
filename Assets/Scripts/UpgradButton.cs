using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradButton : MonoBehaviour
{
   [SerializeField] private Image icon;

   public void set(UpgradeData upgradeData)
   {
      icon.sprite = upgradeData.icon;
   }

   public void Clean()
   {

      icon.sprite = null;

   }
}
