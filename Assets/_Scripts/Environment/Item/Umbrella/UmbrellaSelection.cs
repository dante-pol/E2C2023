using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaSelection : MonoBehaviour
{
    [SerializeField] private GameObject _player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _player.gameObject.GetComponent<BuffsAndDebuffs>().UmbrellaEffectStart();
            Destroy(gameObject);
        }
    }
}
