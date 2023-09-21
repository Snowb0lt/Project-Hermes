using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    private Player player;
    private Rigidbody2D playerRb;
    private PlayerData playerData;

    [SerializeField] private int ThrusterForce;

    private void Start()
    {
        player = GameObject.FindAnyObjectByType<Player>();
        playerData = GameObject.FindAnyObjectByType<PlayerData>();
    }

    public void ThrusterControls()
    {
            if(Input.GetKey(KeyCode.Space) && player.areWingsOut)
            {
                Debug.Log("Thruster Working");
                playerRb.AddForce(new Vector2(ThrusterForce, 1), ForceMode2D.Force);
            }
            if(Input.GetKeyUp(KeyCode.Space) || !player.areWingsOut)
            {
                Debug.Log("thruster Stopped");
                return;
            }
    }
}
