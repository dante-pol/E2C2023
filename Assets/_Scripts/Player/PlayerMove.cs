using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private VariableJoystick _joystick;
    [SerializeField] [Range(1, 50)] public float Speed = 2.5f;
    [SerializeField] [Range(5, 50)] public float MaxSpeed = 15;
    [SerializeField] private float _velocityY;

    public Vector2 SlideForce;
    private float _velocityX;
    private Rigidbody2D _rb;
    private Buffs _buffs;
    private Animator _animator;

    public bool IsSlide;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _buffs = GetComponent<Buffs>();
        _animator = GetComponent<Animator>();
    }

    
    private void Update()
    {
        if(GetComponent<PlayerModel>()._death == false && !IsSlide)
        {
            _velocityX = _joystick.Horizontal * Speed;

            if (_joystick.Horizontal > 0)
            {
                _rb.velocity -= new Vector2(_velocityX, 0);
            }
            else if (_joystick.Horizontal < 0)
            {
                _rb.velocity += new Vector2(_velocityX, 0);
            }

            SlowingFlow();
            Flip();

            _rb.velocity = new Vector2(MaxSpeed * _joystick.Horizontal, _velocityY);
            _animator.SetFloat("velocityHorizontal", Mathf.Abs(_velocityX));
            _animator.SetFloat("velocityVertical", _velocityY);
        }

        if (IsSlide)
        {
            _rb.AddForce(SlideForce, ForceMode2D.Impulse);
        }
    }

    public void SlowingFlow()
    {
        if (_buffs.UmbrellaPickUp == true)
        {
            if (_rb.velocity.y < 0)
            {
                _velocityY = _buffs._slowingDownTheFall;
            }

            else
            {
                _velocityY = _rb.velocity.y;
            }
        }
        else
        {
            _velocityY = _rb.velocity.y;
        }
    }

    private void Flip()
    {
        if(_joystick.Horizontal < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(_joystick.Horizontal > 0) 
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}

