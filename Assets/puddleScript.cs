using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddleScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Animator animator;

    bool Alive = true;
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
            }
        }
        get { return _health; }
    }

    public float _health = 3;
    public void Start()
    {
        animator.SetBool("Alive", true);
    }
    void OnHit(float damage) {
        Debug.Log("Puddle hit for " + damage);
        Health -= damage;
    }
}
