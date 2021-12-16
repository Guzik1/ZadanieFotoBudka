using UnityEngine;

public class CameraScrollZoom : MonoBehaviour
{
    public float sensitivity = 5f;
    public float maxZoom = 8f;
    float minZoom;

    float currentZoom = 0f;

    void Start()
    {
        minZoom = transform.position.z;
        maxZoom = minZoom + maxZoom;

        currentZoom = minZoom;
    }

    void Update()
    {
        currentZoom += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        transform.position = new Vector3(transform.position.x, transform.position.y, currentZoom);
    }
}