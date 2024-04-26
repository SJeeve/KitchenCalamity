using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnHit(float damage) {
        Debug.Log("Puddle hit for " + damage);
    }
}
