using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keris : MonoBehaviour
{
    [SerializeField] private GameObject cariKeris;
    [SerializeField] private GameObject dapetKeris;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController player))
        {
            Destroy(gameObject);
            cariKeris.SetActive(false);
            dapetKeris.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dapetKeris.SetActive(false);
    }
}
