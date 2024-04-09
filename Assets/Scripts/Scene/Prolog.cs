using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Prolog : MonoBehaviour
{
    public VideoPlayer vplayer;

    private void Start()
    {
        vplayer.loopPointReached += OnVideoFinished;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Level 1");
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene("Level 1");
    }
}
