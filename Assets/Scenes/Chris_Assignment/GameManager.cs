using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject resultPanel;
    public Text resultText;
    public bool isGameOver = false;

    void Start()
    {
        Time.timeScale = 1;
        resultPanel.SetActive(false);
    }

    public void WinGame()
    {
        GameOver("You Win!");
    }

    public void LoseGame()
    {
        GameOver("You Lose!");
    }

    void GameOver(string message)
    {
        isGameOver = true;
        Time.timeScale = 0;
        resultPanel.SetActive(true);
        resultText.text = message;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainTitle");
    }
}