using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    private Vector3 movmentVector;

    [SerializeField] private float speed = 3f;

    private Animate animate;
    
    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movmentVector = new Vector3();
        animate = GetComponent<Animate>();
    }

    // Update is called once per frame
    void Update()
    {
        movmentVector.x = Input.GetAxisRaw("Horizontal");
        movmentVector.y = Input.GetAxisRaw("Vertical");
        
        animate.horizontal = movmentVector.x;
        
        movmentVector *= speed;

       
        
        rgbd2d.velocity = movmentVector;
    }
}
