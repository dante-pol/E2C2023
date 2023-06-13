using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private int _addHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var playerHealth = collision.gameObject.GetComponent<PlayerModel>();

        if (playerHealth != null)
        {
            if (playerHealth.GetHealth() < playerHealth.GetMaxHealth())
            {
                playerHealth.AddHealth(_addHealth);

                Destroy(gameObject);
            }
        }
    }
}
