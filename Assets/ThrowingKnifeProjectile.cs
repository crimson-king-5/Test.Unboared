using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ThrowingKnifeProjectile : MonoBehaviour
{
    private Vector3 _direction;
    [SerializeField] private float speed;
    public int damage = 5;
    private bool hitDetected = false;
    
    private void Update()
    {
        transform.position += _direction * (speed * Time.deltaTime);

       /* if (Time.frameCount %6 == 0)
        {
            Collider2D[] hit = Physics2D.OverlapCapsuleAll(transform.position, 0.7f);
            foreach (Collider2D c in hit)
            {
                Enemy enemy = c.GetComponent<Enemy>();
                if (enemy != null)
                {
                    
                }

            }
        }*/
    }
    public void SetDirection(float dir_x, float dir_y)
    {
        _direction = new Vector3(dir_x, dir_y);

        if (dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }

   
    
}
