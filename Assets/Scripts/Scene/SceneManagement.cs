using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject gameOverUi;
    public GameObject pauseUi;
    //bool gameHasEnded = false;
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
        //gameHasEnded = true;
        gameOverUi.SetActive(true);
        Time.timeScale = 0f; // Menghentikan waktu
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Kembali ke kecepatan waktu normal
        //gameHasEnded = false; // Reset status game over
        SceneManager.LoadSceneAsync("Level 1");
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
        Time.timeScale = 1f;
    }


}
