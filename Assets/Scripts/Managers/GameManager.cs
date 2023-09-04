using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance { get; private set; }

    [Header("Spawning Conventions")]
    [SerializeField] private float time = 0.0f;
    [SerializeField] private float _spawnTime;
    [SerializeField] private Transform _spawnpoint;
    private int _numberToSpawn;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _spawnOffset;

    [SerializeField] private List<GameObject> _spawnables = new List<GameObject>();
 

    void Start()
    {
        if (_instance == null || _instance != this)
        {
            Destroy(_instance);
            _instance = this;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        SpawnObjects();
        
    }

    private void LateUpdate()
    {
        _spawnpoint.position = new Vector2((_player.transform.position.x + _spawnOffset), _spawnpoint.position.y);
        _distanceFromStart = Mathf.FloorToInt(Vector2.Distance(startPoint.transform.position, _player.transform.position));
    }

    private void SpawnObjects()
    {
        if (time >= _spawnTime)
        {
            //Resets the Clock
            time = 0.0f;
            //Generate a random number to select what spawns
            _numberToSpawn = Random.Range(0, _spawnables.Count);
            //Spawn The Object
            GameObject.Instantiate(_spawnables[_numberToSpawn], _spawnpoint);
            Debug.Log($"{_spawnables[_numberToSpawn].name} has spawned");
        }
    }

    //calculate distance
    public float _distanceFromStart { get; private set; }
    public float _moneyEarned { get; private set; }
    public float _totalMoney { get; private set; }
    [SerializeField] private GameObject startPoint;
    public void GetDistanceFromStart()
    {

        Debug.Log($"The distance from start is {_distanceFromStart}m");

        //Convert that into money

        _moneyEarned = Mathf.FloorToInt(_distanceFromStart / 6);
        Debug.Log($"Earned a total of {_moneyEarned} this round");

        _totalMoney += _moneyEarned;
    }
}
