using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{

    public static EventsManager _instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _instance = this;
    }

    public event Action onDayExtended;
    public void DayExtended()
    {
        if (onDayExtended != null) onDayExtended(); 
    }

    public event Action EndingTheGame;
    public void EndTheGame()
    {

    }

    public event Action spawnTheWall;
    public void SpawnTheWall()
    {

    }
}
