using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceness : MonoBehaviour
{
 public void IScene(int number)
    {
      SceneManager.LoadScene(number);
    }
}
