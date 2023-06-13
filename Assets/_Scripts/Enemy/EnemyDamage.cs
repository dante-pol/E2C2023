using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] private int _damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var playerHealth = collision.gameObject.GetComponent<PlayerModel>();

        if (playerHealth != null)
        {
            playerHealth.RemoveHealth(_damage);
        }
    }
}
