using UnityEngine;

public class PlayerRollAndClimbing : MonoBehaviour
{
    [SerializeField] private VariableJoystick _joystick;
    [SerializeField] private BoxCollider2D _bcRoll;
    [SerializeField] private float _velocityUp;
    [SerializeField] private float _velocityDown;
    [SerializeField] private float _climbingSpeed;
    [SerializeField] private float _climbingMaxSpeed;
    private BoxCollider2D _bc;
    private Rigidbody2D _rb;
    private PlayerMove _pm;
    private Animator _animator;
    [HideInInspector] public bool UnderCeiling;
    public bool IsClimbing;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _bc = GetComponent<BoxCollider2D>();
        _pm = GetComponent<PlayerMove>();
    }

    void FixedUpdate()
    {
        if (_joystick.Vertical < -0.5 || UnderCeiling)
        {
            _animator.SetBool("IsSquat", true);
            _pm.Speed = 1f;
            _pm.MaxSpeed = 5;
            _bc.enabled = false;
            _bcRoll.enabled = true;
        }
        else if (_joystick.Vertical > 0.75 && IsClimbing)
        {
            _rb.AddForce(new Vector2(0, _velocityUp));
            _pm.Speed = _climbingSpeed;
            _pm.MaxSpeed = _climbingMaxSpeed;
        }
        else if (_joystick.Vertical < 0.75 && IsClimbing)
        {
            _rb.AddForce(new Vector2(0, _velocityDown));
            _pm.Speed = _climbingSpeed;
            _pm.MaxSpeed = _climbingMaxSpeed;
        }
        else
        {
            _animator.SetBool("IsSquat", false);
            _pm.Speed = 2.5f;
            _pm.MaxSpeed = 15;
            _bc.enabled = true;
            _bcRoll.enabled = false;
        }
    }
}
