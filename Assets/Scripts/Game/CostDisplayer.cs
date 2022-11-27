using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostDisplayer : MonoBehaviour
{
    // Tower ID
    public int towerID;

    // Cost value
    public int towerCost;

    // Initialise (Fetch the value from the spawner tower list)
    void Start()
    {
        towerCost = GameManager.instance.spawner.TowerCost(towerID);
        GetComponent<UnityEngine.UI.Text>().text = towerCost.ToString();
    }
}
