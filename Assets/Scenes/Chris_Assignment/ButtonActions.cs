using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public void Start()
    {
        SceneManager.LoadScene("Chris_Assignment");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainTaitle");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
