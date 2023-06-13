using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForse;
    private Rigidbody2D _rb;
    private bool _onGround;
    void Start()
    {
        _rb= GetComponent<Rigidbody2D>();
        //_jumpForse = 65;
    }

    public void Jump()
    {
        if (_onGround)
        {
            _rb.AddForce(new Vector2(0, _jumpForse), ForceMode2D.Impulse);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _onGround = false;
        }
    }
}
