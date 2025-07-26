// Scripts/MainMenuUI.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Chris_Assignment"); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
