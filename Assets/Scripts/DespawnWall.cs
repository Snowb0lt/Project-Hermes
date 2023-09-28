using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnWall : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _wallOffset;


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector2((_player.transform.position.x + _wallOffset), transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Debug.Log($"{collision.name} has been destroyed");
    }
}
