using System;
using UnityEngine;

public class ParallaxCamera : MonoBehaviour
{
    public Action<float> onCameraTranslate;
    private float oldPositionX;

    void Start()
    {
        oldPositionX = transform.position.x;
    }

    void Update()
    {
        float deltaX = transform.position.x - oldPositionX;
        oldPositionX = transform.position.x;

        if (Mathf.Abs(deltaX) > Mathf.Epsilon)
        {
            onCameraTranslate?.Invoke(deltaX);
        }
    }
}