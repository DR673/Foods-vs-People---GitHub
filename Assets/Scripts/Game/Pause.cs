using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public bool gameIsPaused = false;

    public Image pauseButtonImage;

    public void gamePause()
    {
        if (gameIsPaused == false)
        {
            gameIsPaused = !gameIsPaused;

            //turn the pause can on
            pauseButtonImage.GetComponent<Image>().color = new Color(1f, 1f, 1f);

            return;
        }

        if (gameIsPaused == true)
        {
            gameIsPaused = !gameIsPaused;

            //turn the pause can on
            pauseButtonImage.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);

            return;
        }
    }
}
