using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    private Player player;
    private Rigidbody2D playerRb;
    private PlayerData playerData;

    [SerializeField] private int ThrusterForce;

    private void Awake()
    {
        player = GameObject.FindAnyObjectByType<Player>().GetComponent<Player>();
        playerData = GameObject.FindAnyObjectByType<PlayerData>().GetComponent<PlayerData>();
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    public void FireThrusters()
    {
        Debug.Log("Thrusters Active");
        playerRb.AddForce(new Vector2(ThrusterForce, 1), ForceMode2D.Force);
    }

    public void StopThrusters()
    {
        Debug.Log("thruster Stopped");
        return;
    }
}
