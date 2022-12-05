using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public GameObject scriptManager;

    public Image progressBarPart1;
    public Image progressBarPart2;
    public Image progressBarPart3;
    public Image progressBarPart4;
    public Image progressBarPart5;
    public Image progressBarPart6;
    public Image progressBarPart7;
    public Image progressBarPart8;
    public Image progressBarPart9;
    public Image progressBarPart10;

    void Update()
    {
        scriptManager = GameObject.FindGameObjectWithTag("ScriptManager");

        ProgressBarUpdater();
    }

    void ProgressBarUpdater()
    {
        if (scriptManager.GetComponent<EnemySpawner>().enemiesKilled > (scriptManager.GetComponent<EnemySpawner>().totalNumberOfEnemies * 0.1f) - 0.1f)
        {
            // Change the image colour to light green
            progressBarPart1.GetComponent<Image>().color = new Color(0, 0.75f, 0);
        }

        if (scriptManager.GetComponent<EnemySpawner>().enemiesKilled > (scriptManager.GetComponent<EnemySpawner>().totalNumberOfEnemies * 0.2f) - 0.1f)
        {
            // Change the image colour to light green
            progressBarPart2.GetComponent<Image>().color = new Color(0, 0.75f, 0);
        }

        if (scriptManager.GetComponent<EnemySpawner>().enemiesKilled > (scriptManager.GetComponent<EnemySpawner>().totalNumberOfEnemies * 0.3f) - 0.1f)
        {
            // Change the image colour to light green
            progressBarPart3.GetComponent<Image>().color = new Color(0, 0.75f, 0);
        }

        if (scriptManager.GetComponent<EnemySpawner>().enemiesKilled > (scriptManager.GetComponent<EnemySpawner>().totalNumberOfEnemies * 0.4f) - 0.1f)
        {
            // Change the image colour to light green
            progressBarPart4.GetComponent<Image>().color = new Color(0, 0.75f, 0);
        }

        if (scriptManager.GetComponent<EnemySpawner>().enemiesKilled > (scriptManager.GetComponent<EnemySpawner>().totalNumberOfEnemies * 0.5f) - 0.1f)
        {
            // Change the image colour to light green
            progressBarPart5.GetComponent<Image>().color = new Color(0, 0.75f, 0);
        }

        if (scriptManager.GetComponent<EnemySpawner>().enemiesKilled > (scriptManager.GetComponent<EnemySpawner>().totalNumberOfEnemies * 0.6f) - 0.1f)
        {
            // Change the image colour to light green
            progressBarPart6.GetComponent<Image>().color = new Color(0, 0.75f, 0);
        }

        if (scriptManager.GetComponent<EnemySpawner>().enemiesKilled > (scriptManager.GetComponent<EnemySpawner>().totalNumberOfEnemies * 0.7f) - 0.1f)
        {
            // Change the image colour to light green
            progressBarPart7.GetComponent<Image>().color = new Color(0, 0.75f, 0);
        }

        if (scriptManager.GetComponent<EnemySpawner>().enemiesKilled > (scriptManager.GetComponent<EnemySpawner>().totalNumberOfEnemies * 0.8f) - 0.1f)
        {
            // Change the image colour to light green
            progressBarPart8.GetComponent<Image>().color = new Color(0, 0.75f, 0);
        }

        if (scriptManager.GetComponent<EnemySpawner>().enemiesKilled > (scriptManager.GetComponent<EnemySpawner>().totalNumberOfEnemies * 0.9f) - 0.1f)
        {
            // Change the image colour to light green
            progressBarPart9.GetComponent<Image>().color = new Color(0, 0.75f, 0);
        }

        if (scriptManager.GetComponent<EnemySpawner>().enemiesKilled > (scriptManager.GetComponent<EnemySpawner>().totalNumberOfEnemies * 1.0f) - 0.1f)
        {
            // Change the image colour to light green
            progressBarPart10.GetComponent<Image>().color = new Color(0, 0.75f, 0);
        }
    }
}
