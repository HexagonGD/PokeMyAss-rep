using UnityEngine;

public class Player : MonoBehaviour
{
    private IInput _input;
    private RoadBuilder _roadBuilder;
    private Transform _transform;

    [SerializeField] private Vector3 _offsetSpawnRoad;

    [Header("Speed")]
    [Min(0)][SerializeField] private float _forwardSpeed;
    [Min(0)][SerializeField] private float _sideSpeed;

    [Header("Side")]
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;

    private void Awake()
    {
        _transform = transform;
        _input = new KeyboardInput();
        _roadBuilder = new RoadBuilder(_transform.position + _offsetSpawnRoad, 20f, 6);
    }

    private void Update()
    {
        var deltaX = _input.GetHorizontalInput();
        var position = _transform.position;
        position.x = Mathf.Clamp(_transform.position.x + deltaX * _sideSpeed * Time.deltaTime, _minX, _maxX);
        position.z += _forwardSpeed * Time.deltaTime;
        _transform.position = position;
        _roadBuilder.HandlePosition(_transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        Destroy(gameObject);
    }
}
