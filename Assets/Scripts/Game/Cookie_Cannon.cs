using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie_Cannon : MonoBehaviour
{
    // Health
    public int health;

    // Damage
    public int damage;

    // Prefab (Shooting item)
    public GameObject prefab_shootItem;

    // Shoot interval
    public float interval;

    // Cost
    public int cost;

    // Initiate (start the shooting interval)
    void Start()
    {
        // Start the shooting interval IEnumerator
        StartCoroutine(ShootDelay());
    }

    // Interval for shooting
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(interval);
        ShootItem();
        StartCoroutine(ShootDelay());
    }

    // Shoot an item
    void ShootItem()
    {
        // Instantiate shoot item
        GameObject shotItem = Instantiate(prefab_shootItem, transform);

        // Set its values
        shotItem.GetComponent<ShootItem>().Init(damage);
    }

    // Lose health
    public void ShootHealth()
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
        Debug.Log("Cookie Cannon is dead");
        Destroy(gameObject);
    }
}