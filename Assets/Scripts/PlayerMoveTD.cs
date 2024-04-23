using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveTD : MonoBehaviour
{
    // Start is called before the first frame update
    bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool("IsMoving", isMoving);
        }
    }
    public float moveSpeed = 150f;

    public float maxSpeed = 8f;

    public float idleFriction = 0.9f;

    Rigidbody2D rb;

    Animator animator;

    SpriteRenderer spriteRenderer;

    Vector2 moveInput = Vector2.zero;

    bool isMoving = false;
    bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove && moveInput != Vector2.zero)
        {
            //Is moving
            rb.velocity = Vector2.ClampMagnitude(rb.velocity + (moveInput * moveSpeed * Time.deltaTime), maxSpeed);

            if (moveInput.x > 0)
            {
                spriteRenderer.flipX = true;
            } else if (moveInput.x < 0)
            {
                spriteRenderer.flipX = false;
            }

            IsMoving = true;
        } else
        {
            Not moving
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
            IsMoving = false;
        }
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }

    void LockMovement()
    {
        canMove = false;
    }

    void UnlockMovement()
    {
        canMove = true;
    }
}
