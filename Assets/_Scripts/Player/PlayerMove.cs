using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] [Range(1, 50)] public float Speed;
    [SerializeField] [Range(5, 50)] public float MaxSpeed;
    [SerializeField] private VariableJoystick _joystick;
    private float _velocityX;
    public Rigidbody2D _rb;

    [Header("Buffs")]
    BuffsAndDebuffs _buffs;
    [SerializeField] private float _slowingDownTheFall;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _velocityX = _joystick.Horizontal * Speed;
        _rb.velocity += new Vector2(_velocityX, 0);

        

        if (Mathf.Abs(_rb.velocity.sqrMagnitude) > MaxSpeed * MaxSpeed)
        {
            _rb.velocity = new Vector2(MaxSpeed * _joystick.Horizontal, _rb.velocity.y);

        }
    }
}

