using UnityEngine;

public class FollowPoint : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
    private Transform _transform;
    private Vector3 _position;

    [SerializeField] private bool _freezePositionX;
    [SerializeField] private bool _freezePositionY;
    [SerializeField] private bool _freezePositionZ;

    private void Awake()
    {
        _transform = transform;
        _position = _transform.position;
    }

    private void Update()
    {
        Vector3 result;
        result.x = _freezePositionX ? _position.x : _followTarget.position.x;
        result.y = _freezePositionY ? _position.y : _followTarget.position.y;
        result.z = _freezePositionZ ? _position.z : _followTarget.position.z;
        _transform.position = result;
    }
}
