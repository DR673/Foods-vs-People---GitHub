using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float health;

    public int cost;

    private Vector3Int cellPosition;

    protected virtual void Start()
    {

    }

    public virtual void Init(Vector3Int cellPos)
    {
        cellPosition = cellPos;
    }

    // Lose health
    public virtual bool LoseHealth(float amount)
    {
        health -= amount;

        // Blink red animation
        StartCoroutine(BlinkRed());

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
        FindObjectOfType<Spawner>().RevertCellState(cellPosition);
        Destroy(gameObject);
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
