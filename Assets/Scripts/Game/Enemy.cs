using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Health
    public float health;

    // Attack power
    public int attackPower;

    // Attack interval
    public float attackInterval;

    // Move speed
    public float moveSpeed;

    public Animator animator;

    //Penda Edit
    public GameObject scriptManager;

    Coroutine attackOrder;
    Tower detectedTower;

    void Update()
    {
        if (!detectedTower)
        {
            Move();
        }

        scriptManager = GameObject.FindGameObjectWithTag("ScriptManager");
    }

    IEnumerator Attack()
    {
        animator.Play("Attack", 0, 0);

        // Wait attackInterval
        yield return new WaitForSeconds(attackInterval);

        // Attack again
        attackOrder = StartCoroutine(Attack());
    }

    // Moving forward
    void Move()
    {
        animator.Play("Move");

        transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
    }

    public void InflictDamage()
    {
        bool towerDied = detectedTower.LoseHealth(attackPower);

        if (towerDied)
        {
            detectedTower = null;

            StopCoroutine(attackOrder);
        }
    }

    // Lose health
    public void LoseHealth(float amount)
    {
        // Decrease health value by amount of damage that projectile does
        health -= amount;

        // Blink red animation
        StartCoroutine(BlinkRed());

        // Check if health is 0 then destroy enemy
        if (health <= 0)
        {
            scriptManager.GetComponent<EnemySpawner>().enemiesKilled++;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (detectedTower)
        {
            return;
        }

        if (collision.tag == "Tower")
        {
            detectedTower = collision.gameObject.GetComponent<Tower>();
            attackOrder = StartCoroutine(Attack());
        }

        if (collision.tag == "FinishLine")
        {
            //Penda Edit
            scriptManager.GetComponent<HealthSystem>().LoseHealth();
        }

        if (collision.tag == "Out")
        {
            scriptManager.GetComponent<EnemySpawner>().enemiesKilled++;

            Destroy(gameObject);
        }
    }
}
