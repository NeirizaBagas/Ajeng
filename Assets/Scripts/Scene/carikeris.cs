using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carikeris : MonoBehaviour
{
    [SerializeField] private GameObject halangan;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController player))
        {
            halangan.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        halangan.SetActive(false);
    }
}
