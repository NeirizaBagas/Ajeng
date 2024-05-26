using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject gameOverUi;
    bool gameHasEnded = false;
    public float restartDelay = 1f;

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
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            gameOverUi.SetActive(true);
            Time.timeScale = 0f; // Menghentikan waktu
        }
    }

    public void RestartGame()
    {
        if (gameHasEnded)
        {
            gameHasEnded = false; // Reset status game over
            SceneManager.LoadSceneAsync("Level 1");
            Time.timeScale = 1f; // Kembali ke kecepatan waktu normal
        }
    }

    public void BackToMainMenu()
    {
        if (gameHasEnded)
        {
            gameHasEnded = false; // Reset status game over
            SceneManager.LoadScene("Main Menu");
            Time.timeScale = 1f; // Kembali ke kecepatan waktu normal
        }
    }
}
