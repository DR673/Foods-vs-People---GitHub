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
        FindObjectOfType<Spawner>().RevertCellState(cellPosition);
        Destroy(gameObject);
    }
}
