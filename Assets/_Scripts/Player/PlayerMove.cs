using System.Timers;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private VariableJoystick _joystick;
    [SerializeField] [Range(1, 50)] public float Speed;
    [SerializeField] [Range(5, 50)] public float MaxSpeed;
    [SerializeField] private float _velocityY;

    public Vector2 SlideForce;
    private float _velocityX;
    private Rigidbody2D _rb;
    private Buffs _buffs;
    public bool IsSlide;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _buffs = GetComponent<Buffs>();
    }

    
    private void Update()
    {
        if (IsSlide == false)
        {

        
            _velocityX = _joystick.Horizontal * Speed;
            _rb.velocity += new Vector2(_velocityX, 0);

            SlowingFlow();

            if (Mathf.Abs(_rb.velocity.sqrMagnitude) > MaxSpeed * MaxSpeed)
            {
                _rb.velocity = new Vector2(MaxSpeed * _joystick.Horizontal, _velocityY);
            }
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
}

