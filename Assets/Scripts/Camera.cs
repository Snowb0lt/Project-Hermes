using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _cameraOffset;
    // Start is called before the first frame update

    private void LateUpdate()
    {
        transform.position = _player.position + _cameraOffset;
    }
}
