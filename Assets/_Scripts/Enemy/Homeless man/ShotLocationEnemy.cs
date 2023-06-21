using UnityEngine;

public class ShotLocationEnemy : MonoBehaviour
{
     public bool _isShot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isShot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isShot = false;
        }
    }
}
