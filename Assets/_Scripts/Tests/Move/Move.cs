using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    [SerializeField] private float Speed;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        var Horizontal = Input.GetAxis("Horizontal");
        var Vertical = Input.GetAxis("Vertical");

        _rigidbody.velocity = new Vector2(Horizontal * Speed, _rigidbody.velocity.y);
    }
}
