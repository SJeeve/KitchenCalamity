using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddleScript : MonoBehaviour, IDamageable
{
    // Start is called before the first frame update
    [SerializeField] public Animator animator;

    bool Alive = true;
    Rigidbody2D rb;
    Collider2D physicsCollider;
    public float Health
    {
        set
        {
            if(value < _health)
            {
                animator.SetTrigger("Hit");
            }
            _health = value;

            if (_health <= 0)
            {
                animator.SetBool("Alive", false);
                Targetable = false;
            }
        }
        get { return _health; }
    }

    public bool Targetable { get { return _targetable; } 
    set {
            _targetable = value;

            rb.simulated = value;
            physicsCollider.enabled = value;
        }
    }

    public float _health = 3;
    public bool _targetable = true;
    public void Start()
    {
        animator.SetBool("Alive", true);

        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }
    public void OnHit(float damage) {
        Health -= damage;
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;
        rb.AddForce(knockback);
    }

    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }
}
