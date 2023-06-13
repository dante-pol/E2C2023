using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] [Range(1, 50)] public float Speed;
    [SerializeField] [Range(5, 50)] public float MaxSpeed;
    [SerializeField] private VariableJoystick _joystick;
    private Rigidbody2D _rb;
    private Buffs _buffs;
    private float _velocityX;
    [SerializeField] private float _velocityY;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _buffs = GetComponent<Buffs>();
    }

    
    private void Update()
    {
        _velocityX = _joystick.Horizontal * Speed;
        _rb.velocity += new Vector2(_velocityX, 0);

        SlowingFlow();

      //  if (Mathf.Abs(_rb.velocity.sqrMagnitude) > MaxSpeed * MaxSpeed)
      //  {
            _rb.velocity = new Vector2(MaxSpeed * _joystick.Horizontal, _velocityY);
      //  }
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

