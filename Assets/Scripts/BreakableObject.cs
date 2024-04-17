using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite brokenSprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            if(brokenSprite != null)
            {
                spriteRenderer.sprite = brokenSprite;
                GetComponent<BoxCollider>().enabled = false;
            } else
            {
                Destroy(gameObject);
            }
                
        }
    }
}
