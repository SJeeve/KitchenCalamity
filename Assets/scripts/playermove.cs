using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float speed = 2f;
    public bool FacingLeft = true;

    public Rigidbody2D rb;
    public Transform tf;

    public void Update()
    {
        horizontal = Input.GetAxisRaw("horizontal");
        vertical = Input.GetAxisRaw("vertical");

        if (Input.GetButton )
        flip();
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector2 (horizontal * speed, vertical * speed);

    }

    private void flip()
    {
        if (!FacingLeft && horizontal < 0f || FacingLeft && horizontal > 0f)
        {
            FacingLeft = !FacingLeft;
            Vector3 v3 = transform.localScale;
            v3.x *= -1f;
            transform.localScale = v3;
        }
    }

}
