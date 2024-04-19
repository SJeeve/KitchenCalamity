using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthtracker : MonoBehaviour
{

    public int maxHealth = 30;
    public int currentHealth;

    public healthbar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            currentHealth -= 5;

            healthbar.setHealth(currentHealth);
        }
    }
}
