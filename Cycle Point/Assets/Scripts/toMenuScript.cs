using UnityEngine;
using UnityEngine.SceneManagement;

public class toMenuScript : MonoBehaviour
{
    public void toMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void toGame()
    {
        SceneManager.LoadScene("Game");
    }

}
