using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager _instance { get; private set; }

    [Header("Spawning Conventions")]
    [SerializeField] private float time = 0.0f;
    [SerializeField] private float _spawnTime;
    private int _numberToSpawn;

    private UpgradeSO upgradeSO;

    [SerializeField] private Player _playerScript;
    [SerializeField] private float _spawnOffset;

    [SerializeField] private GameObject _ground;
    [SerializeField] private GameObject _player;
    [SerializeField] private PlayerData _playerData;

    [SerializeField] private UnityEvent startANewRun;

    //Check if the game has started
    private bool _isGameGoing = false;

    [SerializeField] private List<GameObject> _spawnables = new List<GameObject>();
    void Start()
    {        
        if (_instance == null || _instance != this)
        {
            Destroy(_instance);
            _instance = this;
        }

        _player = GameObject.Find("Player");
        _ground = GameObject.Find("Ground");
        _playerData = PlayerData.FindObjectOfType<PlayerData>();

        
    }

    void Update()
    {
        time += Time.deltaTime;
        SpawnObjects();
        
    }

    /// <summary>
    /// Perform secondary update tasks
    /// </summary>
    private void LateUpdate()
    {
        _distanceFromStart = Mathf.FloorToInt(Vector2.Distance(startPoint.transform.position, _player.transform.position));
    }

    /// <summary>
    /// When the player is launched, activate and control spawning conventions
    /// </summary>
    public void BeginTheGame()
    {
        if (!_isGameGoing)
        {
            _isGameGoing = true;
            time = 0.0f;
        }

    }

    public void AddToSpawning()
    {
        foreach (GameObject spawnable in _playerData.UnlockedSpawnables)
        {
            if (!_spawnables.Contains(spawnable))
            {
                _spawnables.Add(spawnable);
            }
            else
            {
                return;
            }
            
        }
    }

    [SerializeField] private float spawnRangeHigh;
    private void SpawnObjects()
    {
        AddToSpawning();
        if (_isGameGoing)
        {
            if (time >= _spawnTime)
            {
                //Resets the Clock
                time = 0.0f;
                //Generate a random number to select what spawns
                _numberToSpawn = Random.Range(0, _spawnables.Count);
                //Spawn The Object
                //Set the Range for how high or low the object 
                GameObject.Instantiate(_spawnables[_numberToSpawn], new Vector3((_player.transform.position.x + _spawnOffset), (_player.transform.position.y + Random.Range(_ground.transform.position.y + 2, spawnRangeHigh))), Quaternion.identity);
                Debug.Log($"{_spawnables[_numberToSpawn].name} has spawned");
            }
        }
        else
        {
            return;
        }
        
    }

    /// <summary>
    /// calculate distance of the player from the start point and turn it into currency at the end of the run
    /// </summary>
    public int _distanceFromStart { get; private set; }
    public int _moneyEarned { get; private set; }
    public int _totalMoney { get; private set; }
    [SerializeField] private GameObject startPoint;

    private int _CoinDivider;
    public void GetDistanceFromStart()
    {

        //Convert that into money
        if (!_playerData.UpgradeDictionary.ContainsKey(PlayerData.Stats.GoldPerRun))
        {
            _CoinDivider = 0;
        }
        else
        {
            _CoinDivider = Mathf.RoundToInt(_playerData.UpgradeDictionary[PlayerData.Stats.GoldPerRun]);
        }
        _moneyEarned = (_distanceFromStart / (10 - _CoinDivider));
        Debug.Log($"Earned a total of {_moneyEarned} this round");

        //Add to total money

        //Set New Record Distance
        if (_playerData._longestDistance < _distanceFromStart)
        {
            _playerData._longestDistance = _distanceFromStart;
        }
    }

    public void SaveCoinTotal()
    {
        //Add to total
        _totalMoney = _playerData._coins + _moneyEarned;

        //Save new total
        _playerData._coins = _totalMoney;
    }

    public void NewRun()
    {
        CountTheDay();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void MoveToShop()
    {
        CountTheDay();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void CountTheDay()
    {
        _playerData.ChangeTheDays();
    }
}