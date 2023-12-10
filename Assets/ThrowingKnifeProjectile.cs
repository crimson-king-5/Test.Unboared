using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnifeProjectile : MonoBehaviour
{
    private Vector3 _direction;
    [SerializeField] private float speed;

    
    private void Update()
    {
        transform.position += _direction * (speed * Time.deltaTime);
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
