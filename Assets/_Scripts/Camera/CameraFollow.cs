
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;

    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    private Vector3 minXminY;
    private Vector3 maxXminY;
    private Vector3 minXmaxY;
    private Vector3 maxXmaxY;

    private void Start()
    {
        minXminY = Camera.main.ViewportToWorldPoint(new Vector2(0, -0.5f));
        maxXminY = Camera.main.ViewportToWorldPoint(new Vector2(1, -0.5f));
        minXmaxY = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));
        maxXmaxY = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }
    private void Update()
    {
        Vector3 PlayerPosition = _playerTransform.localPosition;

        PlayerPosition.z = -10;

        if(_playerTransform.position.x <= _minX)
        {
            PlayerPosition.x = _minX;
            transform.position = PlayerPosition;
        } 

        else if (_playerTransform.position.x >= _maxX)
        {
            PlayerPosition.x = _maxX;
            transform.position = PlayerPosition;
        }
        else
        {
            transform.position = PlayerPosition;
        }

        if (_playerTransform.position.y <= _minY)
        {
            PlayerPosition.y = _minY;
            transform.position = PlayerPosition;
        }
        else if (_playerTransform.position.y >= _maxY)
        {
            PlayerPosition.y = _maxY;
            transform.position = PlayerPosition;
        } 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;


        Gizmos.DrawLine(new Vector3(_minX + minXminY.x, _minY + minXminY.y), new Vector3(_maxX + maxXminY.x, _minY + maxXminY.y)); // Bottom
        Gizmos.DrawLine(new Vector3(_minX + minXmaxY.x, _maxY + minXmaxY.y / 2), new Vector3(_maxX + maxXmaxY.x, _maxY + maxXmaxY.y / 2)); // Top

        Gizmos.DrawLine(new Vector3(_minX + minXmaxY.x, _maxY + minXmaxY.y / 2), new Vector3(_minX + minXminY.x, _minY + minXminY.y)); // Left
        Gizmos.DrawLine(new Vector3(_maxX + maxXmaxY.x, _maxY + maxXmaxY.y / 2), new Vector3(_maxX + maxXminY.x, _minY + maxXminY.y)); // Right
    }

    //  minXminY 
    //  maxXminY
    //  minXmaxY
    //  maxXmaxY
}
