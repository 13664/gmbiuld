using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleScenes : MonoBehaviour
{
    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OpenLevel1()
    {
        SceneManager.LoadScene("Main");
    }

    public void OpenLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void OpenLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void OpenLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }
}
