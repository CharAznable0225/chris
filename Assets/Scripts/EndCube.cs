using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCube : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over: Player entered end zone");

           
            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true);
            }

            
            Time.timeScale = 0f;

            
            SceneManager.LoadScene("GameOverMenu");
        }
    }
}
