using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twin_Cookie_Cannon : Tower
{
    // Damage
    public float damage;

    // Prefab (Shooting item)
    public GameObject prefab_shootItem;

    // Prefab (Shooting item)
    public GameObject prefab_shootItem2;

    // Shoot interval
    public float interval;

    // Point that projectiles fires from
    public Transform FireFromPoint;

    // Point that projectiles fires from
    public Transform FireFromPoint2;

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
        ShootItem();
        StartCoroutine(ShootDelay());
    }

    // Shoot an item
    void ShootItem()
    {
        // Instantiate shoot item
        GameObject shotItem = Instantiate(prefab_shootItem, FireFromPoint.transform);

        // Instantiate shoot item
        GameObject shotItem2 = Instantiate(prefab_shootItem2, FireFromPoint2.transform);

        // Set its values
        shotItem.GetComponent<ShootItem>().Init(damage);
    }
}
