using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float movespeed;
    public Rigidbody2D rb;
    private Vector2 input;

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();
        rb.velocity = input * movespeed * Time.deltaTime;


    }

}
