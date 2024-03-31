using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 offset;


    // Update is called once per frame
    void Update()
    {
        if (playerController != null)
        {
            Vector3 desirePos = playerController.transform.position + offset;

            transform.position = Vector3.Lerp(transform.position, desirePos, moveSpeed);
        }
        
    }

    private void Start()
    {
        
    }
}
