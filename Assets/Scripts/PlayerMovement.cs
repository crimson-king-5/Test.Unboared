using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    [HideInInspector]
    public Vector3 movmentVector;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    
    [SerializeField] private float speed = 3f;

    private Animate animate;
    
    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movmentVector = new Vector3();
        animate = GetComponent<Animate>();
    }

    private void Start()
    {
        lastHorizontalVector = -1f;
        lastVerticalVector = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        movmentVector.x = Input.GetAxisRaw("Horizontal");
        movmentVector.y = Input.GetAxisRaw("Vertical");

        if (movmentVector.x != 0)
        {
            lastHorizontalVector = movmentVector.x;
        }

        if (movmentVector.y != 0 )
        {
            lastVerticalVector = movmentVector.y;
        }
        
        animate.horizontal = movmentVector.x;
        
        movmentVector *= speed;

       
        
        rgbd2d.velocity = movmentVector;
    }
}
