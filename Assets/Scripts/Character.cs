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
   private bool isDead = false;

   public float hpRegenerationRate = 1f;
   public float hpRegenerationTimer;
   
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

   private void Update()
   {
      hpRegenerationTimer += Time.deltaTime * hpRegenerationRate;
      if (hpRegenerationTimer > 1f)
      {
         Heal(1);
         hpRegenerationTimer -= 1f;
      }
   }

   public void TamkeDamage(int damage)
   {
        if(isDead == true) { return; }
      ApplyAmrmor(ref damage);
      
      currentHp -= damage;
      if (currentHp <= 0)
      {
            GetComponent<PlayerGameOver>().GameOver();
            isDead = true;
        
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
