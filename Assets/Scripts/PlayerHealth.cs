using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public int maxHealth;

    public SpriteRenderer playerSr;
    public SpriteRenderer armSr;
    public SpriteRenderer weaponSr;
    public Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            playerSr.enabled = false;
            movement.enabled = false;
            armSr.enabled = false;
            weaponSr.enabled = false;
        }
    }
}
