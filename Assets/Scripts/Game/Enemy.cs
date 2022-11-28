using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Cookie_Cannon CookieCannonScript;

    // Health
    public float health;

    // Attack power
    public int attackPower;

    // Move speed
    public float moveSpeed;

    void Update()
    {
        Move();
    }

    // Moving forward
    void Move()
    {
        transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
    }

    // Lose health
    public void LoseHealth()
    {
        // Decrease health value by amount of damage that projectile does
        health -= CookieCannonScript.damage;

        // Blink red animation
        StartCoroutine(BlinkRed());

        // Check if health is 0 then destroy enemy
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator BlinkRed()
    {
        // Change the sprite renderer colour to red
        GetComponent<SpriteRenderer>().color = Color.red;

        // Wait for really small amount of time
        yield return new WaitForSeconds(0.2f);

        // Revert to default colour
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
