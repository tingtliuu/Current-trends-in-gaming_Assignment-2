using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueStickFollow : MonoBehaviour
{
    public Transform playerCamera;  // Reference to the player's camera
    public Vector3 positionOffset = new Vector3(0.5f, -0.2f, 1f);  // Adjust these values to fine-tune position offset
    public Vector3 rotationOffset = new Vector3(0f, 180f, 0f);  // Adjust these values to fine-tune rotation offset

    void Update()
    {
        // Set gun position and rotation to match the camera with offsets
        transform.position = playerCamera.position + positionOffset;
        transform.rotation = playerCamera.rotation * Quaternion.Euler(rotationOffset);
    }
}
