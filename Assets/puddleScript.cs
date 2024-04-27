using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddleScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Animator animator;
    public float Health
    {
        set
        {
            _health = value;

            if (_health <= 0)
            {
                animator.SetTrigger("Death");
            }
        }
        get { return _health; }
    }

    public float _health = 3;

    void OnHit(float damage, float id) {
        Debug.Log("Puddle hit for " + damage);
        Health -= damage;
    }
}
