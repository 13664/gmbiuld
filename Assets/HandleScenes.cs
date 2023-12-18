using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleScenes : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1;
    }
    public void StopGame()
    {
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
        StopGame();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        StartGame();
    }

    public void OpenLevel1()
    {
        SceneManager.LoadScene("Main");
        StartGame();
    }

    public void OpenLevel2()
    {
        SceneManager.LoadScene("Level 2");
        StartGame();
    }

    public void OpenLevel3()
    {
        SceneManager.LoadScene("Level 3");
        StartGame();
    }
    public void OpenLevel4()
    {
        SceneManager.LoadScene("Level 4");
        StartGame();
    }
}
