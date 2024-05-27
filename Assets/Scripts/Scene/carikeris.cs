using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class carikeris : MonoBehaviour
{
    [SerializeField] private GameObject hintKeris;
    [SerializeField] private GameObject deteksiKeris;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController player))
        {
            hintKeris.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hintKeris.SetActive(false);
        Destroy(deteksiKeris);
    }
}
