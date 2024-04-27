using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    // Start is called before the first frame update

    public Collider2D swordCollider;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.SendMessage("OnHit", swordDamage);
    }

}
