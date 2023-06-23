using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comtimegame : MonoBehaviour
{
    public GameObject panel;

    public void icomtimegame()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }
}
