using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement: MonoBehaviour
{
    public GameObject gameOverUi;
    bool gameHasEnded = false;
    public float restartDelay = 1f;

   public void PlayGame()
    {
        MainMenuAudioManager.instance.musicSource.Stop();
        SceneManager.LoadScene("Prolog");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EndGame()
    {
        if(!gameHasEnded)
        {
            gameHasEnded = true;
            gameOverUi.SetActive(true);
        }
        
    }

    public void RestartGame()
    {
        if (gameHasEnded)
        {
            SceneManager.LoadScene("Level 1");
        }
    }

    public void BackToMainMenu()
    {
        if (gameHasEnded)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
