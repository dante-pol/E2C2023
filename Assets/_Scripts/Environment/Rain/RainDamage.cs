using System.Collections;
using UnityEngine;

public class RainDamage : MonoBehaviour
{
    private PlayerModel _playerModel;
    private bool isTrigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Buffs>().UmbrellaPickUp == false)
        {
            _playerModel = collision.gameObject.GetComponent<PlayerModel>();
            isTrigger = true;
            StartCoroutine(Damage());
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTrigger = false;
        }
    }

    private IEnumerator Damage()
    {
        if (isTrigger == true)
        {
            if (_playerModel.gameObject.GetComponent<Buffs>().UmbrellaPickUp == false)
            {
                _playerModel.RemoveHealth(1);
                yield return new WaitForSeconds(3);
            }
            StartCoroutine(Damage());
        }
        else
        {
            yield return null;
        }
    }
}
