using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShieldOnPlayer : MonoBehaviour
{


    public void DisableShield()
    {
        Debug.Log(0);
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var shield = collision.gameObject.GetComponent<Shield>();
        if (shield != null)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
