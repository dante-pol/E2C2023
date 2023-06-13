using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Count;

    public void CoinDestroy()
    {
        Destroy(gameObject);
    }
}
