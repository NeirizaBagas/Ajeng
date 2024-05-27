using System.Collections;
using UnityEngine;

public class Keris : MonoBehaviour
{
    [SerializeField] private GameObject penghalang;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController player))
        {
            penghalang.SetActive(false);
            Destroy(gameObject);
        }
    }
}
