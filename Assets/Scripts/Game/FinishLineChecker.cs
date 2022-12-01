using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FinishLine")
        {
            GetComponent<HealthSystem>().LoseHealth();
        }
    }
}
