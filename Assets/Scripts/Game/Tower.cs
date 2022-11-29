using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float health;

    public int cost;

    protected virtual void Start()
    {

    }

    // Lose health
    public virtual bool LoseHealth(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
            return true;
        }

        return false;
    }

    // Die
    protected virtual void Die()
    {
        Debug.Log("Pretzel Shield is dead");
        Destroy(gameObject);
    }
}
