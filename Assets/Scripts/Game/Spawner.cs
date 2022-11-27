using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    // ID of tower to spawn
    public List<GameObject> towersPrefabs;

    // Transform of the spawning towers (Root Object)
    public Transform spawnTowerRoot;

    // List of towers (UI)
    public List<Image> towersUI;

    // List of towers (prefabs) that will be instantiated
    int spawnID = -1;

    // Spawnpoints Tilemap
    public Tilemap spawnTilemap;

    private void Update()
    {
        if (CanSpawn())
        {
            DetectSpawnPoint();
        }
    }

    bool CanSpawn()
    {
        if (spawnID == -1)
        {
            return false;
        }

        else
            return true;
    }
    
    void DetectSpawnPoint()
    {
        // Detect when mouse is clicked (first touch clicked)
        if (Input.GetMouseButtonDown(0))
        {
            // Get the world space position of the mouse
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Get the position of the cell on the tilemap
            var cellPosDefault = spawnTilemap.WorldToCell(mousePos);

            // Get the center position of the cell
            var cellPosCentered = spawnTilemap.GetCellCenterWorld(cellPosDefault);

            // Check if we can spawn in that cell (collied)
            if (spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                int towerCost = TowerCost(spawnID);

                // Check if currency is enough to spawn
                if (GameManager.instance.currency.EnoughCurrency(towerCost))
                {
                    // Use the amount of cost from the currency available
                    GameManager.instance.currency.Use(towerCost);

                    // Spawn the tower
                    SpawnTower(cellPosCentered);

                    // Disable the collider
                    spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.None);
                }
                else
                {
                    Debug.Log("Not enough currency");
                }
            }
        }
    }

    public int TowerCost(int id)
    {
        switch (id)
        {
            case 0: return towersPrefabs[id].GetComponent<Worker_Hive>().cost;
            case 1: return towersPrefabs[id].GetComponent<Pretzel_Shield>().cost;
            // case 2: return towersPrefabs[0].GetComponent<CookieCannon>().cost;
            default: return -1;
        }
    }
    
    void SpawnTower(Vector3 position)
    {
        GameObject tower = Instantiate(towersPrefabs[spawnID], spawnTowerRoot);
        tower.transform.position = position;

        DeselectTowers();
    }
    
    public void SelectTower(int id)
    {
        DeselectTowers();

        // Set the spawn ID
        spawnID = id;

        // Highlight the tower
        towersUI[spawnID].color = Color.white;
    }

    public void DeselectTowers()
    {
        spawnID = -1;

        foreach (var t in towersUI)
        {
            t.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }
}
