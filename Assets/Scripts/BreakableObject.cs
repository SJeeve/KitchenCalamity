using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SpriteRenderer spriteRenderer;

    public float Health
    {
        set
        {
            _health = value;

            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
        get { return _health; }
    }

    public float _health = 1;
    
    void OnHit(float damage)
    {
        Debug.Log("Breakable object hit");
        Health -= damage;
    }
}
