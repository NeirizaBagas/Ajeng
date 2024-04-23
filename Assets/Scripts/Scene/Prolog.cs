using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Prolog : MonoBehaviour
{
    [SerializeField] GameObject next;

    //public VideoPlayer vplayer;

    //private void Start()
    //{
    //    vplayer.loopPointReached += OnVideoFinished;
    //}

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Level 1");
        }
    }

    //private void OnEnable()
    //{
    //    SceneManager.LoadSceneAsync("Level 1");
    //}

    public void NextScene()
    {
        SceneManager.LoadScene("Level 1");
    }
}
