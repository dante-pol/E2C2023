using System.Collections;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    [Header("Umbrella Stats")]
    [SerializeField] private float _timeUmbrella;
    /*[HideInInspector]*/ public bool UmbrellaPickUp;
    [Range(-5, 0)] public float _slowingDownTheFall;

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
