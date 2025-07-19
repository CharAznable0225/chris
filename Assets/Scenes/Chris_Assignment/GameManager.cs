// Scripts/GameManager.cs
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
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    public void Victory()
    {
        if (isGameOver) return;
        isGameOver = true;
        Time.timeScale = 0f;
        victoryUI.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
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

    void Update()
    {
        if (!isGameOver && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Victory();
        }
    }
}