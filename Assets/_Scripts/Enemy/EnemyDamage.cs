using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] private int _damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerModel>().RemoveHealth(_damage);
        }
    }
}
