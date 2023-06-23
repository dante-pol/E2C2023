using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool isAttack;
    private bool _nextToEnemy;
    private Animator _animator;
    [SerializeField] private GameObject _enemy;

    private void Start()
    {
        _animator = GameObject.FindObjectOfType<PlayerModel>().GetComponent<Animator>();
    }
    public void EnemyAttack()
    {
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("AttackPlayer"))
        {
            _animator.SetTrigger("AttackTrigger");
            if (_nextToEnemy)
            {
                _enemy.GetComponent<EnemyModel>().RemoveHealth(1);
            }
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
