using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EndingWall : MonoBehaviour
{
    [SerializeField] private UnityEvent endTheGame;

    [SerializeField] private NavigationManager navigationManager;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player = GameObject.FindAnyObjectByType<Player>().GetComponent<Player>();
        navigationManager = FindAnyObjectByType<NavigationManager>().GetComponent<NavigationManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _player.StopThePlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EndTheGame();
        }
    }
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private float fadeSpeed;

    private void EndTheGame()
    {
        //TODO: Slow the game down, fade to black.
        //Time.timeScale = 0.5f;

        //Color objectColor = blackScreen.GetComponent<Image>().color;
        //fadeSpeed = objectColor.a;

        //while (blackScreen.GetComponent<Image>().color.a < 1) 
        //{
        //    objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeSpeed);
        //    blackScreen.GetComponent<Image>().color = objectColor;
        //}
        navigationManager.WinCondition();
    }
}
