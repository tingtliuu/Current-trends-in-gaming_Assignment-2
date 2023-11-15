using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // The target object to rotate around
    public float rotationSpeed = 2f;
    public float heightOffset;

    void Start()
    {
        // Set the initial position of the camera higher on the Y-axis
        transform.position = new Vector3(transform.position.x, target.position.y + heightOffset, transform.position.z);
        
    }
    void Update()
    {
            transform.LookAt(target);

            // Get input for horizontal rotation
            float horizontalInput = Input.GetAxis("Horizontal");

            // Calculate the new rotation based on input
            float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;

            // Rotate the camera around the target
            transform.RotateAround(target.position, target.up, rotationAmount);
    }
}





