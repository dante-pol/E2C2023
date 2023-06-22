using UnityEngine;

public class PlayerAttackTest : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void AttackTest()
    {
        if (GetComponent<PlayerModel>().Death == false)
        {
            _animator.SetTrigger("AttackTrigger");
        }
            
    }
}
