using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactor;

    public void Move(float delta)
    {
        Vector3 newPosition = transform.position;
        newPosition.x += delta * parallaxFactor;
        transform.position = newPosition;
    }
}