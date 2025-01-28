using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Leaderboard() 
    {
        SceneManager.LoadScene("leaderborad");
    }

    public void Back()
    {
        SceneManager.LoadScene("menu");
    }
}
