using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidBody2;

    private float _speedPerFrame = 0.4f;
    
    void Start()
    {
        _rigidBody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidBody2.velocity = new Vector2(10,0);
    }
}
