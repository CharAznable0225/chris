using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverUI;
    public GameObject victoryUI;
    public GameObject pauseUI;

    private bool isGameOver = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        Time.timeScale = 2f;
        gameOverUI.SetActive(true);
    }

    public void Victory()
    {
        if (isGameOver) return;
        isGameOver = true;
        Time.timeScale = 2f;
        victoryUI.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 2f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 2f;
        SceneManager.LoadScene("MainTitle");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }
}