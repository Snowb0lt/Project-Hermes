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
}
