using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pause : MonoBehaviour
{
    public GameObject panel;

 public void ipause()
    {
        panel.SetActive(true);  
        Time.timeScale = 0;
    }
}
