using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : Enemy
{
    public GameObject minerGameObject;

    public SpriteRenderer minerSpriteRenderer;

    private void Start()
    {
        StartCoroutine(WaitTimeBeforeMining());
    }

    IEnumerator WaitTimeBeforeMining()
    {
        // Wait for really small amount of time
        yield return new WaitForSeconds(9.5f);

        MoveMiner();
    }

    void MoveMiner()
    {
        Vector3 temporaryMinerPosition = minerGameObject.transform.position;

        temporaryMinerPosition.x = -3.6f;

        minerGameObject.transform.position = new Vector3(temporaryMinerPosition.x, temporaryMinerPosition.y, temporaryMinerPosition.z);

        moveSpeed = -0.25f;

        minerSpriteRenderer.flipX = true;
    }
}
