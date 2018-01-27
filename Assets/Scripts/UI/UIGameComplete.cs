using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameComplete : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadSceneAsync("Game View");
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}