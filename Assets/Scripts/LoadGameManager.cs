using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameManager : MonoBehaviour
{
    public void LoadingGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(7);
    }

    public void RestartLoading()
    {
        SceneManager.LoadScene(8);
    }

    public void EndingGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
