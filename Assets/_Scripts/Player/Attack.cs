using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _nextToEnemy;
    private GameObject _enemy;

    public void EnemyAttack()
    {
        if (_nextToEnemy)
        {
            _enemy.GetComponent<EnemyModel>().RemoveHealth(1);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _nextToEnemy = true;
            _enemy = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _nextToEnemy = false;
        }
    }
}
