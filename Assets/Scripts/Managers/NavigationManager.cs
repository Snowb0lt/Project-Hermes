using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
    public PlayerData playerData;

    private void Awake()
    {
        playerData = GameObject.FindAnyObjectByType<PlayerData>().GetComponent<PlayerData>();
    }

    /// <summary>
    /// Navigation between The Menu, the Game, and the Shop
    /// </summary>
    /// 
    public void StartTheGame()
    {
        SceneManager.LoadScene(1);
    }
    public void NewRun()
    {
        if (playerData._daysLeft <= 0)
        {
            Debug.Log("You are out of time. Game Over");
        }
        else
        {
            CountTheDay();
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(1);
        }
        
    }

    public void MoveToShop()
    {
        if (playerData._daysLeft <= 0)
        {
            Debug.Log("You are out of time. Game Over");
        }
        else
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(2);
        }

    }

    public void ToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void CountTheDay()
    {
        playerData.ChangeTheDays();
    }

    public void WinCondition()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
