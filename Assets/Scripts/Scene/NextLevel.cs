using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private GameObject endingScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController player))
        {
            Debug.Log("Ending");
            endingScene.SetActive(true);
            //SceneManager.LoadSceneAsync("Level 2");
        }
    }
}
