using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play() 
    {
        SceneManager.LoadScene("Initialization");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
