// Scripts/MainMenuUI.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // 改成你的主場景名稱
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
