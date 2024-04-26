using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    // Start is called before the first frame update

    public Collider2D swordCollider;

    public float swordDamage = 1f;

    void Start()
    {
        if(swordCollider == null)
        {
            Debug.LogWarning("Sword Collider not set");
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        collider.SendMessage("OnHit", swordDamage);
    }
}
