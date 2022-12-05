using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    // The UI text for the health count
    public Text txt_healthCount;

    // The default value of the health count (used for initiation)
    public int defaultHealthCount;

    // Current health count
    public int healthCount;

    public GameObject panelYouLose;

    // Initiate the health system (reset the health count);
    public void Init()
    {
        healthCount = defaultHealthCount;

        txt_healthCount.text = healthCount.ToString();
    }

    // Lose health count
    public void LoseHealth()
    {
        if (healthCount < 1)
        {
            return;
        }

        healthCount--;
        txt_healthCount.text = healthCount.ToString();

        CheckHealthCount();
    }

    // Check health count for losing
    void CheckHealthCount()
    {
        if (healthCount < 1)
        {
            StartCoroutine(WaitBeforeRestartingScene());
        }
    }

    IEnumerator WaitBeforeRestartingScene()
    {
        panelYouLose.SetActive(true);

        yield return new WaitForSeconds(5f);

        BackToMainMenuFromLoss();
    }

    public void BackToMainMenuFromLoss()
    {
        SceneManager.LoadScene(0);
    }
}
