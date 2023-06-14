using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float fireRate;
    private float _nextFire;

    [SerializeField] private ShotLocationEnemy _shotLocation;

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
        if(_shotLocation._isShot == true)
        {
            if (Time.time > _nextFire)
            {
                Instantiate(_bullet, transform.position, Quaternion.identity);
                _nextFire = Time.time + fireRate;
            }
        }
    }


}
