using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private GameObject _target;
    private GameObject _enemy;

    private float _targetHorizontal;
    private float _enemyHorizontal;

    private float _dist;
    private float _nextHorizontal;
    private float _baseVertical;
    private float _hieght;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _enemy = GameObject.FindGameObjectWithTag("Enemy");

        _targetHorizontal = _target.transform.position.x;
        _enemyHorizontal = _enemy.transform.position.x;
        _baseVertical = Mathf.Lerp(_enemy.transform.position.y, _target.transform.position.y, (_nextHorizontal - _enemyHorizontal) / _dist);

        Destroy(gameObject, _lifeTime);
    }
    private void Update()
    {

        _dist = _targetHorizontal - _enemyHorizontal;
        _nextHorizontal = Mathf.MoveTowards(transform.position.x, _targetHorizontal, _speed * Time.deltaTime);

        _hieght = 2 * (_nextHorizontal - _enemyHorizontal) * (_nextHorizontal - _targetHorizontal) / (-0.75f * _dist * _dist);

        Vector3 movePosition = new Vector3(_nextHorizontal, _baseVertical + _hieght, transform.position.z);
        transform.position = movePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _target.gameObject.GetComponent<PlayerModel>().RemoveHealth(1);
            Destroy(gameObject);
        }
    }
}
