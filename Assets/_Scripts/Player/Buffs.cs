using System.Collections;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    [Header("Umbrella Stats")]
    [SerializeField] private float _timeUmbrella;
    [HideInInspector]public bool UmbrellaPickUp;
    [Range(-5, 0)] public float _slowingDownTheFall;
    public bool Buff1;
    public bool Buff2;
    public bool Buff3;

    #region Ubrella buff
    public void Umbrella()
    {
        StartCoroutine(UmbrellaCorotinue());
    }
    public IEnumerator UmbrellaCorotinue()
    {
        UmbrellaPickUp = true;

        yield return new WaitForSeconds(_timeUmbrella);

        UmbrellaPickUp = false;
    }
    #endregion
}
