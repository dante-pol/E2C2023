using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoll : MonoBehaviour
{
    [SerializeField] private VariableJoystick _joystick;
    [SerializeField] private BoxCollider2D _bcRoll;
    private BoxCollider2D _bc;
    private PlayerMove _pm;
    private SpriteRenderer _sr;
    private Animator _animator;

    private void Start()
    {
        _bc = GetComponent<BoxCollider2D>();
        _pm = GetComponent<PlayerMove>();
        _sr = GetComponent<SpriteRenderer>(); 
        _animator = GetComponent<Animator>();   
    }

    private void Update()
    {
        if (GetComponent<PlayerModel>()._death == false && GetComponent<PlayerMove>().IsSlide == false)
        {
            if (_joystick.Vertical < -0.5)
            {
                _pm.Speed = 1f;
                _pm.MaxSpeed = 5;
                _bc.enabled = false;
                _bcRoll.enabled = true;

                _sr.flipX = true;

                _animator.SetBool("IsSquat", true);
            }
            else
            {
                if (gameObject.GetComponent<Buffs>().Slowingdown == true)
                {
                    _pm.Speed = 1f;
                    _pm.MaxSpeed = 10;
                    _bc.enabled = true;
                    _bcRoll.enabled = false;

                    _sr.flipX = false;

                    _animator.SetBool("IsSquat", false);
                }
                else
                {
                    _pm.Speed = 2.5f;
                    _pm.MaxSpeed = 15;
                    _bc.enabled = true;
                    _bcRoll.enabled = false;

                    _sr.flipX = false;

                    _animator.SetBool("IsSquat", false);
                }
            }
        }
    }
}
