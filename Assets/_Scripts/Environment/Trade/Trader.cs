using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trader : MonoBehaviour
{
    [SerializeField] private GameObject _traderButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _traderButton.SetActive(true);
            _traderButton.transform.GetChild(0).gameObject.SetActive(true);
            _traderButton.GetComponent<Image>().enabled = true;
            _traderButton.GetComponent<Button>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _traderButton.SetActive(false);
            _traderButton.transform.GetChild(0).gameObject.SetActive(false);
            _traderButton.GetComponent<Image>().enabled = false;
            _traderButton.GetComponent<Button>().enabled = false;
        }
    }
}
