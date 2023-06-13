using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    private Rigidbody2D _rb;
    PlayerMove target;
    Vector2 moveDirection;
    [SerializeField] private int _damage;

    GameObject Player;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerMove>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        _rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Player.gameObject.GetComponent<PlayerModel>().RemoveHealth(_damage);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
