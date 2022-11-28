using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootItem : MonoBehaviour
{

    // Graphics (the sprite renderer)
    public Transform graphics;

    // Damage
    public float damage;

    // Speed
    public float flySpeed, rotateSpeed;

    // Initiate
    public void Init(float dmg)
    {
        damage = dmg;
    }

    // Trigger with enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Shot the enemy");
            Destroy(gameObject);
        }

        if (collision.tag == "Out")
        {
            Destroy(gameObject);
        }
    }

    // Handle rotation and flying
    void Update()
    {
        Rotate();
        FlyForward();
    }

    void Rotate()
    {
        graphics.Rotate(new Vector3(0, 0, -rotateSpeed * Time.deltaTime));
    }

    void FlyForward()
    {
        transform.Translate(transform.right * flySpeed * Time.deltaTime);
    }
}
