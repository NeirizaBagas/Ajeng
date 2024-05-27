using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject gameOverUi;
<<<<<<< HEAD
    //public GameObject pauseUi;
=======
    public GameObject pauseUi;
>>>>>>> 03ba2f4ee3e9266b881f357d7942a7529735aab3
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
<<<<<<< HEAD
        //pauseUi.SetActive(false);
=======
        pauseUi.SetActive(false);
>>>>>>> 03ba2f4ee3e9266b881f357d7942a7529735aab3
        Time.timeScale = 1f;
    }


}
