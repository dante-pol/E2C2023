using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private float _lifeTime;

    private Rigidbody2D _rb;
    private PlayerMove _target;
    private Vector2 _moveDirection;
    private Vector2 _targetPosition;

    private float _time;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _target = GameObject.FindObjectOfType<PlayerMove>();
        _moveDirection = (_target.transform.position - transform.position).normalized * _moveSpeed;

        if(_target.transform.position.y <= transform.position.y)
        {
            _targetPosition.y = _target.transform.position.y + 0.25f;
        }
        else
        {
            _targetPosition.y = _target.transform.position.y;
        }
               
        Destroy(gameObject, _lifeTime);
    }
    private void Update()
    {
        _time += Time.deltaTime;
        _rb.velocity = new Vector2(_moveDirection.x, _moveDirection.y + _targetPosition.y - _time);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        var playerHealth = collision.gameObject.GetComponent<PlayerModel>();

        if (playerHealth != null)
        {
            playerHealth.RemoveHealth(_damage);
        }    
    }
}
