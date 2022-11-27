using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pretzel_Shield : MonoBehaviour
{
    // Health
    public int health;

    // Cost
    public int cost;

    // Initiate
    private void Start()
    {
        
    }

    // Lose health
    public void LoseHealth()
    {
        health -= 250;

        if (health <= 0)
        {
            Die();
        }
    }

    // Die
    public void Die()
    {
        Debug.Log("Pretzel Shield is dead");
        Destroy(gameObject);
    }
}
