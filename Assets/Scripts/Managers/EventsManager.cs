using System;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    private GameManager gameManager;
    public static EventsManager _instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            UnityEngine.Object.Destroy(gameObject);
        }
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
