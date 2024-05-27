using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject gameOverUi;
    public GameObject pauseUi;
    public GameObject pauseButton;
    public GameObject optionUi;
    //bool gameHasEnded = false;
    public float restartDelay = 1f;

    private void Awake()
    {
        if (pauseUi != null)
        {
            pauseUi.SetActive(false);
        }
        if (pauseButton != null)
        {
            pauseButton.SetActive(true);
        }
        if (optionUi != null)
        {
            optionUi.SetActive(false);
        }
    }

    private void Update()
    {
        AltPause();
    }

    public void PlayGame()
    {
        MainMenuAudioManager.instance.musicSource.Stop();
        SceneManager.LoadScene("Prolog");
        Time.timeScale = 1f; // Kembali ke kecepatan waktu normal
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EndGame()
    {
        //gameHasEnded = true;
        gameOverUi.SetActive(true);
        Time.timeScale = 0f; // Menghentikan waktu
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Kembali ke kecepatan waktu normal
        //gameHasEnded = false; // Reset status game over
        pauseUi.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Memuat ulang scene saat ini
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f; // Kembali ke kecepatan waktu normal
        //gameHasEnded = false; // Reset status game over
        SceneManager.LoadScene("Main Menu");
    }

    public void Resume()
    {
        pauseUi.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Debug.Log("Pause Function Called");
        pauseUi.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Option()
    {
        optionUi.SetActive(true);
        pauseUi.SetActive(false);
        Time.timeScale = 0f;
    }

    public void AltPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pause");
            pauseUi.SetActive(true);
            pauseButton.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
