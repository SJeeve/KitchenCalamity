using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddleScript : MonoBehaviour
{
    public float damage = 1;

    public float knockbackForce = 100f;
    public void OnCollisionEnter2D(Collision2D collider)
    {
        IDamageable damageable = collider.collider.GetComponent<IDamageable>();

        if (damageable != null)
        {

            Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;

            Vector2 direction = (Vector2)(collider.gameObject.transform.position - transform.position).normalized;
            Vector2 knockback = direction * knockbackForce;

            damageable.OnHit(damage, knockback);
        }
    }
}
