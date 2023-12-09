using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    
    [SerializeField] private GameObject leftWhipObject;
    [SerializeField] private GameObject rightWhipObject;

    [SerializeField]  private float timeToAttack = 4f;
    private float timer;
    private PlayerMovement playerMove;
    [SerializeField] Vector2 whipAttackSize = new Vector2(4f, 2f);
    [SerializeField] private int whipDamage = 1;
    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Attack()
    {
       
        timer = timeToAttack;
        if (playerMove.lastHorizontalVector > 0)
        {
            rightWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            leftWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamageable e = colliders[i].GetComponent<IDamageable>();
            if (e != null)
            {
               e.TakeDamage(whipDamage);
            }
           
        }
    }
}
