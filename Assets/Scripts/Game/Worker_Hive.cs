using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Worker_Hive : MonoBehaviour
{
    // Health
    public int health;

    // Income value
    public int incomeValue;

    // Interval for income
    public float interval;

    // Honey image object
    public GameObject obj_honey;

    // Cost of tower
    public int cost;

    // Initialise
    void Start()
    {
        StartCoroutine(Interval());
    }
    
    // Interval IEnumerator
    IEnumerator Interval()
    {
        yield return new WaitForSeconds(interval);

        // Trigger the income increase
        IncreaseIncome();

        StartCoroutine(Interval());
    }

    // Trigger income increase
    public void IncreaseIncome()
    {
        GameManager.instance.currency.Gain(incomeValue);

        StartCoroutine(HoneyIndication());
    }

    // Show honey indication over the tower for a short period of time (0.5 seconds)
    IEnumerator HoneyIndication()
    {
        obj_honey.SetActive(true);
        yield return new WaitForSeconds(1f);
        obj_honey.SetActive(false);
    }

    // Lose health
    public void LoseHealth()
    {
        Die();
    }

    // Die
    public void Die()
    {
        health--;

        if (health <= 0)
        {
            Debug.Log("Tower is dead");
            Destroy(gameObject);
        }
    }
}
