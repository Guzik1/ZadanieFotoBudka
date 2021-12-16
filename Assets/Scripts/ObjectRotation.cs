using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float sensitivity;

    Vector3 mouseReference;
    Vector3 mouseOffset;
    Vector3 rotation;
    bool isRotating;

    void Start()
    {
        sensitivity = 0.4f;
        rotation = Vector3.zero;
    }

    void Update()
    {
        if (isRotating)
        {
            mouseOffset = (Input.mousePosition - mouseReference);

            rotation.y = -(mouseOffset.x + mouseOffset.y) * sensitivity;

            transform.Rotate(rotation);

            mouseReference = Input.mousePosition;
        }
    }

    void OnMouseDown()
    {
        mouseReference = Input.mousePosition;
        isRotating = true;
    }

    void OnMouseUp()
    {
        isRotating = false;
    }
}