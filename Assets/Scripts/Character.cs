using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

public class Character : MonoBehaviour
{
   public int maxHp = 1000;
   public int currentHp = 1000;
   public int armor = 0;
   [SerializeField] private StatusBar hpBar;

   [HideInInspector] public Level level;
   [HideInInspector] public Coins coins;
   private void Awake()
   {
      level = GetComponent<Level>();
      coins = GetComponent<Coins>();
   }

   private void Start()
   {
      hpBar.SetState(currentHp, maxHp);
   }

   public void TamkeDamage(int damage)
   {
      ApplyAmrmor(ref damage);
      
      currentHp -= damage;
      if (currentHp <= 0)
      {
         Debug.Log("PlayerDead");
      }
      hpBar.SetState(currentHp, maxHp);
   }

   private void ApplyAmrmor(ref int damage)
   {
      damage -= armor;
      if (damage < 0)
      {
         damage = 0;
      }
   }

   public void Heal(int amount)
   {
      if (currentHp <= 0)
      {
         return;
      }

      currentHp += amount;
      if (currentHp > maxHp)
      {
         currentHp = maxHp;
      }
      hpBar.SetState(currentHp, maxHp);
   }
}
