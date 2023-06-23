using UnityEngine;

public class PlayerRollAndClimbingVerification : MonoBehaviour
{
    [SerializeField] private PlayerRollAndClimbing _prac;
    private Animator _animator;

    private void Start()
    {
        _animator = GameObject.FindObjectOfType<PlayerModel>().GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _prac.UnderCeiling = true;
        }
        if (collision.gameObject.CompareTag("Ladder"))
        {
            _animator.SetBool("isClimb", true);
            _prac.IsClimbing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _prac.UnderCeiling = false;
        }
        if (collision.gameObject.CompareTag("Ladder"))
        {
            _animator.SetBool("isClimb", false);
            _prac.IsClimbing = false;
        }
    }
}
