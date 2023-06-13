using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float fireRate;
    [SerializeField] private float _nextFire;
    [SerializeField] private float _time;
    [SerializeField]private bool isShot;

    private void Start()
    {
        _nextFire = Time.time;
    }

    private void Update()
    {
        TimeToFire();
    }

    private void TimeToFire()
    {
        if(isShot == true)
        {
            if (Time.time > _nextFire)
            {
                Instantiate(_bullet, transform.position, Quaternion.identity);
                _nextFire = Time.time + fireRate;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isShot = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isShot= false;
    }
}
