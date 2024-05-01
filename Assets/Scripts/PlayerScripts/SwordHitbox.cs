using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    // Start is called before the first frame update

    public Collider2D swordCollider;
    public float knockbackForce = 1000f;

    public float swordDamage = 1f;

    public float entityid = 1f;

    void Start()
    {
        if(swordCollider == null)
        {
            Debug.LogWarning("Sword Collider not set");
        }
    }
   /* public void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.SendMessage("OnHit", swordDamage);
    } */

    private void OnTriggerEnter2D(Collider2D collider)
    {
        IDamageable damagebleObject = (IDamageable) collider.GetComponent<IDamageable>();

        if (damagebleObject != null)
        {
            Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;

            Vector2 direction = (Vector2) (collider.gameObject.transform.position - parentPosition).normalized;
            Vector2 knockback = direction * knockbackForce;

            damagebleObject.OnHit(swordDamage, knockback);
        } else {
            Debug.LogWarning("Collider does not implement IDamageable");
        }
    }

}
