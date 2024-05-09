using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddleScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool("IsMoving", isMoving);
        }
    }

    public float damage = 1;

    public float knockbackForce = 100f;

    public float moveSpeed = 500f;

    public DetectionZone detectionZone;

    public Rigidbody2D rb;

    SpriteRenderer spriteRenderer;

    bool isMoving = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        Collider2D detectedObject0 = detectionZone.detectedObject[0];
        if (detectionZone.detectedObject.Count > 0)
        {
            IsMoving = true;
            Vector2 direction = (detectedObject0.transform.position - transform.position).normalized;
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
            if(rb.velocity.x > 0)
            {
                spriteRenderer.flipX = true;
            } else if (rb.velocity.x < 0)
            {
                spriteRenderer.flipX = false;
            }
            
        } else
        {
            IsMoving = false;
        }
    }
    public void OnCollisionEnter2D(Collision2D collider)
    {
        IDamageable damageable = collider.collider.GetComponent<IDamageable>();

        if (damageable != null)
        {

            Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;

            Vector2 direction = (Vector2)(collider.gameObject.transform.position - transform.position).normalized;
            Vector2 knockback = direction * knockbackForce;
            gameObject.GetComponent<Animator>().SetTrigger("Attack");
            damageable.OnHit(damage, knockback);
        }
    }
}
