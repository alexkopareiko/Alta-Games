using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        if (GameManager.instance != null && GameManager.instance.gameIsPaused)
        {
            GameManager.instance.PauseGame(false);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        if (GameManager.instance != null && GameManager.instance.gameIsPaused)
        {
            GameManager.instance.PauseGame(false);
        }
    }
}
