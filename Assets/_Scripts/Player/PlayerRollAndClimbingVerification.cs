using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollAndClimbingVerification : MonoBehaviour
{
    [SerializeField] private PlayerRollAndClimbing _prac;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _prac.UnderCeiling = true;
        }
        else if (collision.gameObject.CompareTag("Ladder"))
        {
            _prac.IsClimbing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _prac.UnderCeiling = false;
        }
        else if (collision.gameObject.CompareTag("Ladder"))
        {
            _prac.IsClimbing = false;
        }
    }
}
