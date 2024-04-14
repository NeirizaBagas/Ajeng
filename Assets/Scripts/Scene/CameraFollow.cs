using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject playerController;


    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0, 0, -20);
        transform.position = playerController.transform.position + offset;
    }

    private void Start()
    {
        Vector3 offset = new Vector3(0, 0, -20);
        transform.position = playerController.transform.position + offset;
    }
}
