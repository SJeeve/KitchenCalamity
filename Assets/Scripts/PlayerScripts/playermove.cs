using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
 
    public float movespeed;
    public Rigidbody2D rb;
    private Vector2 input;
    public Animation ani;
    
    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();
        rb.velocity = input * movespeed * Time.deltaTime;
        if (input.x > 1 || input.y > 1)
        {
            ani.Play();
        }
        
    }



}
