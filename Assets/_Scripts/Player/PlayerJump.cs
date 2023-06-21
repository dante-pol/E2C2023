using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForse;
    private Rigidbody2D _rb;
    private bool _onGround;
    private Animator _animator;
    void Start()
    {
        _rb= GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void Jump()
    {
        if (GetComponent<PlayerModel>().Death == false && GetComponent<PlayerMove>().IsSlide == false)
        {
            if (_onGround)
            {
                _rb.AddForce(new Vector2(0, _jumpForse), ForceMode2D.Impulse);
                //_animator.SetTrigger("JumpTrigger");
            }
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _onGround = true;
            //_animator.SetBool("IsGround", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _onGround = false;
            //_animator.SetBool("IsGround", false);
        }
    }
}
