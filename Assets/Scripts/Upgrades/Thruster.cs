using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Thruster : MonoBehaviour
{
    private Player player;
    private Rigidbody2D playerRb;
    private PlayerData playerData;
    private ThrusterFuel thrusterFuel;

    [SerializeField] private int ThrusterForce;

    [SerializeField] private ParticleSystem particles;

    [SerializeField] private UnityEvent drainFuel;
    [SerializeField] private UnityEvent drainReport;

    private void Awake()
    {
        player = GameObject.FindAnyObjectByType<Player>().GetComponent<Player>();
        playerData = GameObject.FindAnyObjectByType<PlayerData>().GetComponent<PlayerData>();
        playerRb = player.GetComponent<Rigidbody2D>();
        thrusterFuel = GetComponent<ThrusterFuel>();
    }

    public void FireThrusters()
    {
        if (thrusterFuel.fuelAmount > 0)
        {
            particles.gameObject.SetActive(true);
            particles.Play();
            Debug.Log("Thrusters Active");
            playerRb.AddForce(new Vector2(ThrusterForce, 15), ForceMode2D.Force);
            drainFuel.Invoke();
        }
        else
        {
            particles.Stop();
            Debug.Log("Out of Fuel");
        }
    }

    public void StopThrusters()
    {
        particles.Stop();
        particles.gameObject.SetActive(false);
        drainReport.Invoke();
        Debug.Log("thruster Stopped");
        return;
    }
}
