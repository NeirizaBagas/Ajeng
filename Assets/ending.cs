using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour
{
    public void Start()
    {
        Ending();
    }

    public void Ending()
    {
        SceneManager.LoadScene("Level 2");
    }
}
