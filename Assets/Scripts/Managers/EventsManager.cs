using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    private GameManager gameManager;
    public static EventsManager _instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _instance = this;
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }

    public event Action onDayExtended;
    public void DayExtended()
    {
        if (onDayExtended != null) onDayExtended(); 
    }

    public event Action spawnTheWall;
    public void SpawnTheWall()
    {
        if (gameManager._distanceFromStart > gameManager._GoalDistance)
        {
            spawnTheWall?.Invoke();
        }
    }
}
