using UnityEngine;

public class PiranheMove : MonoBehaviour
{
    [SerializeField] private float JumpForce;
    private Rigidbody2D _rb;
    private float _lifeTime = 3f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.AddForce(Vector2.up *  JumpForce, ForceMode2D.Impulse);
        Destroy(gameObject, _lifeTime);
    }
}
