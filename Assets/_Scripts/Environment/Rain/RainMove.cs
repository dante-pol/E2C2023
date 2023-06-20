using System.Collections;
using UnityEngine;

public class RainMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private Vector2 _speed;
    [SerializeField] private float _timeLife;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(RainDestroy());
        _rb.AddForce(_speed, ForceMode2D.Impulse);
    }

    private IEnumerator RainDestroy()
    {
        yield return new WaitForSeconds(_timeLife);
        Destroy(gameObject);
    }
}
