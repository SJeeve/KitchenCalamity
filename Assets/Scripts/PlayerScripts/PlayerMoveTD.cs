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

    public GameObject swordHitbox;

    Collider2D swordCollider;

    public float idleFriction = 0.9f;

    Rigidbody2D rb;

    Animator animator;

    SpriteRenderer spriteRenderer;

    Vector2 moveInput = Vector2.zero;

    Vector3 playerScreenPoint;

    float swordX;
    float swordY;


    bool isMoving = false;
    bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        swordCollider = swordHitbox.GetComponent<Collider2D>();
        playerScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        swordX = gameObject.transform.GetChild(0).gameObject.transform.position.x;
        swordY = gameObject.transform.GetChild(0).gameObject.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Flip player direction based on mouse
        playerScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        if (Input.mousePosition.x > playerScreenPoint.x)
        {
            spriteRenderer.flipX = true;
        } else if (Input.mousePosition.x < playerScreenPoint.x) { 
            spriteRenderer.flipX = false;
        }

        if (canMove && moveInput != Vector2.zero)
        {
            //Is moving
            //rb.velocity = Vector2.ClampMagnitude(rb.velocity + (moveInput * moveSpeed * Time.deltaTime), maxSpeed);

            rb.AddForce(moveInput * moveSpeed * Time.deltaTime);

            if(rb.velocity.magnitude > maxSpeed) {
                float limitedSpeed = Mathf.Lerp(rb.velocity.magnitude, maxSpeed, idleFriction);
                rb.velocity = rb.velocity.normalized* limitedSpeed;
            }

            IsMoving = true;
        } else
        {
            //Not Moving
            //Line below from earlier, delete soon
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
            IsMoving = false;
        }
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void positionSwordHitbox()
    {
        if (Input.mousePosition.x > playerScreenPoint.x)
        {
            gameObject.transform.GetChild(0).gameObject.transform.position = new Vector3(swordX * -1 + gameObject.transform.position.x, swordY + gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (Input.mousePosition.x < playerScreenPoint.x)
        {
            gameObject.transform.GetChild(0).gameObject.transform.position = new Vector3(swordX + gameObject.transform.position.x, swordY + gameObject.transform.position.y, gameObject.transform.position.z);
        }

    }
    void OnFire()
    {
        positionSwordHitbox();
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
