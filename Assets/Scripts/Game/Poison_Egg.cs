using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison_Egg : Tower
{
    // Damage
    public float damage;

    // Prefab (Shooting item)
    public GameObject prefab_shootItem;

    // Shoot interval
    public float interval;

    // Point that projectiles fires from
    public Transform FireFromPoint;

    // Initiate (start the shooting interval)
    protected override void Start()
    {
        // Start the shooting interval IEnumerator
        StartCoroutine(ShootDelay());
    }

    // Interval for shooting
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(interval);

        // Set the armed poison egg game object as a parent to the unarmed poison egg game object

        Destroy(gameObject);

        ShootItem();
    }

    // Shoot an item
    void ShootItem()
    {
        // Instantiate shoot item
        GameObject shotItem = Instantiate(prefab_shootItem, FireFromPoint.transform);

        // Set its values
        shotItem.GetComponent<ShootItem>().Init(damage);
    }
}
