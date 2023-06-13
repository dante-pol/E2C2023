using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpCoins : MonoBehaviour
{
    PlayerModel coincount;

    private void Start()
    {
        coincount = gameObject.GetComponent<PlayerModel>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
