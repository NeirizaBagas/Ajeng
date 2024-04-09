using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float parallaxEffect;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private Vector3 startingPosition; // Tambahkan variabel untuk menyimpan posisi awal objek

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        startingPosition = transform.position; // Simpan posisi awal objek saat mulai
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        // Terapkan efek paralaks pada posisi objek
        Vector3 parallaxOffset = deltaMovement * parallaxEffect;
        transform.position += parallaxOffset;
        lastCameraPosition = cameraTransform.position;

        // Pastikan posisi objek kembali ke posisi awal setiap frame
        transform.position = startingPosition + new Vector3(parallaxOffset.x, parallaxOffset.y, 0f);
    }
}
