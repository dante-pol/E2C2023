using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonActions : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
    }
    public void PlayButton(int id)
    {
        SceneManager.LoadScene(id);
    }
}
