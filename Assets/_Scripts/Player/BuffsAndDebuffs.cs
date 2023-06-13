using System.Collections;
using UnityEngine;

public class BuffsAndDebuffs : MonoBehaviour
{
    private PlayerMove _playerMove;
    private Rigidbody2D _rigidbody;
    [SerializeField]private float _rbY;

    [SerializeField] private float _slowingDownTheFall;
    [SerializeField] private float _timeUmbrella;

    #region Buffs

    public void UmbrellaEffectStart()
    {
        StartCoroutine(UmbrellaEffect()); 
    }
    public IEnumerator UmbrellaEffect()
    {
        _rbY -= _slowingDownTheFall;
        Debug.Log(0);
        yield return new WaitForSeconds(_timeUmbrella);
        Debug.Log(1);
        _rbY += _slowingDownTheFall;
    }
    #endregion


    #region Debuffs

    #endregion
}
