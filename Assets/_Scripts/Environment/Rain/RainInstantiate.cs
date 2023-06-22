using System.Collections;
using UnityEngine;

public class RainInstantiate : MonoBehaviour
{

    [Header("Появление дождя относительно игрока")]
    [SerializeField] private Vector3 SpawnPosition;

    [Header("Время появления дождя")]
    [SerializeField] private int _minTimeForSpawn;
    [SerializeField] private int _maxTimeForSpawn;

    [SerializeField] private GameObject _rainPref;
    private int _spawnRain;
    void Start()
    {
        _spawnRain = Random.Range(_minTimeForSpawn, _maxTimeForSpawn);
        StartCoroutine(SpawnRain());
    }
    private IEnumerator SpawnRain()
    {
        yield return new WaitForSeconds(_spawnRain);
        Instantiate(_rainPref, FindObjectOfType<PlayerModel>().gameObject.transform.position + SpawnPosition, Quaternion.identity);
        _spawnRain = Random.Range(_minTimeForSpawn, _maxTimeForSpawn);
        StartCoroutine(SpawnRain());
    }
}
