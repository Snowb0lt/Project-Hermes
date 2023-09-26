using System.Collections;
using System.Collections.Generic;
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
    public void NewRun()
    {
        CountTheDay();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void MoveToShop()
    {
        CountTheDay();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(2);
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
}
