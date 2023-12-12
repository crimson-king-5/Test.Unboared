using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level : MonoBehaviour
{
   private int level = 1;
   private int experience = 0;
   [SerializeField] private ExperienceBar experienceBar;
   [SerializeField] UpgradePanelManager upgradePanel;
   [SerializeField] private WeaponManager weaponManager;
   [SerializeField] private List<UpgradeData> upgrades;
   private List<UpgradeData> selectedUpgrades;
   
   [SerializeField] private List<UpgradeData> acquiredUpgrades;


   private void Awake()
   {
      weaponManager = GetComponent<WeaponManager>();
   }

   int To_Level_Up
   {
      get
      {
         return level * 1000;
      }
   }

   private void Start()
   {
      experienceBar.UpdateExperienceSlider(experience, To_Level_Up);
      experienceBar.SetLevelText(level);
   }

   public void AddExperience(int amount)
   {
      experience += amount;
      CheckLevelUp();
      experienceBar.UpdateExperienceSlider(experience, To_Level_Up);
   }

   private void CheckLevelUp()
   {
      if (experience >= To_Level_Up)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
       if (selectedUpgrades == null) { selectedUpgrades = new List<UpgradeData>();}
       selectedUpgrades.Clear();
       selectedUpgrades.AddRange(GetUpgrades(4));
       
       
       upgradePanel.OpenPanel(selectedUpgrades);
       experience -= To_Level_Up;
        level += 1;
        experienceBar.SetLevelText(level);
    }
    public List<UpgradeData> GetUpgrades(int count)
    {
       List<UpgradeData> upgradeList = new List<UpgradeData>();
       if (count > upgrades.Count)
       {
          count = upgrades.Count;
       }
       for (int i = 0; i < count; i++)
       {
          upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);
       }
       
       return upgradeList;
    }

    public void Upgrades(int selectedUpgradeId)
    {
       UpgradeData upgradeData = selectedUpgrades[selectedUpgradeId];

       if (acquiredUpgrades == null)
       {
          acquiredUpgrades = new List<UpgradeData>();
       }

       switch (upgradeData.upgradeType)
       {
          case UpgradeType.WeaponUpgrade:
             weaponManager.UpgradeWeapon(upgradeData);
             break;
          case UpgradeType.ItemUpgrade:
             break;
          case UpgradeType.WeaponUnlock:
             weaponManager.AddWeapon(upgradeData.weaponData);
             break;
          case UpgradeType.ItemUnlockn:
             break;
          default:
             throw new ArgumentOutOfRangeException();
       }
       acquiredUpgrades.Add(upgradeData);
       upgrades.Remove(upgradeData);
    }

    public void AddUpgradesIntoTheListOfAvailableUpgrades(List<UpgradeData> upgradesToAdd)
    {
       this.upgrades.AddRange(upgradesToAdd);
       
    }
}
