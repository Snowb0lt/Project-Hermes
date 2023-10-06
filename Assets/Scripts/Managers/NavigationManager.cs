using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Navigates Between Scenes
/// </summary>
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
        Time.timeScale = 1.0f;
        if (playerData._daysLeft <= 0)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            CountTheDay();
            SceneManager.LoadScene(1);
        }
        
    }

    public void MoveToShop()
    {
        Time.timeScale = 1.0f;
        if (playerData._daysLeft <= 0)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
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

    public void ShowGamePremise()
    {
        SceneManager.LoadScene(5);
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
