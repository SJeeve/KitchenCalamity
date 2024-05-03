using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddleScript : MonoBehaviour
{
    public float damage = 1;

    public void OnCollisionEnter2D(Collision2D col)
    {
        IDamageable damageable = col.collider.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.OnHit(damage);
        }
    }
}
