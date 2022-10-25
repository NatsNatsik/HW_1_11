using UnityEngine;

public class controls : MonoBehaviour
{
    private Vector3 previousMousePosition;
    public float Sensitivity;
    public Transform Level;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - previousMousePosition;
            Level.Rotate(0, -delta.x* Sensitivity, 0);
        }
        previousMousePosition = Input.mousePosition;
    }
}
