using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private GameObject _target;
    private GameObject _enemy;
    private Rigidbody2D _rb2D;

    [SerializeField] private float _targetHorizontal;
    [SerializeField] private float _enemyHorizontal;

    [SerializeField] private float _dist;
    [SerializeField] private float _nextHorizontal;
    [SerializeField] private float _baseVertical;
    [SerializeField] private float _hieght;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();

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
        StartCoroutine(Pos());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _target.gameObject.GetComponent<PlayerModel>().RemoveHealth(1);
            Destroy(gameObject);
        }
    }
    private IEnumerator Pos()
    {
        yield return new WaitForSeconds(1);
        if(_hieght == 0)
        {
            Destroy(gameObject);
        }

    }
}
