using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Airboost : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private int _boostAmount;

    private void Awake()
    {
        _player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.attachedRigidbody.AddForce( new Vector2 (_boostAmount, 0));
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Despawn"))
        {
            Destroy(this.gameObject);
        }
    }
}
