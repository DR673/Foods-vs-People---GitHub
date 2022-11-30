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

    //Tile position
    private Vector3Int tilePos;

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
                    SpawnTower(cellPosCentered, cellPosDefault);

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
            case 2: return towersPrefabs[id].GetComponent<Cookie_Cannon>().cost;
            case 3: return towersPrefabs[id].GetComponent<Cereal_Gatling>().cost;
            case 4: return towersPrefabs[id].GetComponent<Reverse_Cookie_Cannon>().cost;
            default: return -1;
        }
    }
    
    void SpawnTower(Vector3 position, Vector3Int cellPosition)
    {
        GameObject tower = Instantiate(towersPrefabs[spawnID], spawnTowerRoot);
        tower.transform.position = position;
        tower.GetComponent<Tower>().Init(cellPosition);

        DeselectTowers();
    }

    public void RevertCellState(Vector3Int pos)
    {
        spawnTilemap.SetColliderType(pos, Tile.ColliderType.Sprite);
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
