using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public bool grabbed;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)) {
            
        }
    }

    void FixedUpdate()
    {

    }
}