using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class FoodRemover : MonoBehaviour
{
    public Spawner spawnHandler;

    public Image trashCanImage;

    void Update()
    {
        //add a mode indicator too!
        if (spawnHandler.addOrRemove)
        {
            //turn the trash can off
            trashCanImage.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
        }
        else
        {
            //turn the trash can on
            trashCanImage.GetComponent<Image>().color = new Color(1f, 1f, 1f);
        }
    }

    public void RemoveFood()
    {
        //Destroy(gameObject);
        spawnHandler.addOrRemove = !spawnHandler.addOrRemove;
    }
}
