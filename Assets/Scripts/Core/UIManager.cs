using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Health playerHealth;
    [SerializeField] private GameObject gameOverScreen;

    [Header("Pause")]
    [SerializeField] private GameObject pauseMenuUI;

    public bool gameIsPaused = false;

    [Header("EndGame")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform endGame;
    [SerializeField] private GameObject endGameMenuUI;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if(playerTransform.position.x >= endGame.position.x)
        {
            EndGame();
        }
    }

    public void GameOverScreen()
    {     
        gameOverScreen.SetActive(true);
        
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void EndGame()
    {
        endGameMenuUI.SetActive(true);
        playerHealth.Deactivate();
    }
}
