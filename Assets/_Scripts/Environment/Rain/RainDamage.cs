using System.Collections;
using UnityEngine;

public class RainDamage : MonoBehaviour
{
    private Buffs _playerBuffs;
    private PlayerModel _playerModel;
    private bool isTrigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Buffs>().UmbrellaPickUp == false)
        {
            _playerBuffs = collision.gameObject.GetComponent<Buffs>();
            _playerModel = collision.gameObject.GetComponent<PlayerModel>();
            isTrigger = true;
            StartCoroutine(Damage());
        }
        else
        {
            return;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTrigger = false;
            collision.gameObject.GetComponent<Buffs>().Slowingdown = false;
        } 
    }

    private IEnumerator Damage()
    {
        if (isTrigger == true)
        {
            if (_playerBuffs.UmbrellaPickUp == false)
            {
                _playerModel.RemoveHealth(1);
                _playerBuffs.Slowingdown = true;
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
