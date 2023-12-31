using System;
using System.Collections;
using UnityEngine;

public class Whiteballmove : MonoBehaviour
{
    private Camera mainCamera;
    public float initialSpeed = 5f;
    public float decelerationFactor = 0.98f;
    public GameObject dest;

    private Vector3 targetPosition;
    private Vector3 moveDirection;
    private Coroutine movementCoroutine; // Keep track of the active coroutine
    private bool isMoving = false;
    private float currentSpeed;


    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0) && isMoving==false)
        {
            isMoving = true;
            // Stop any active coroutine
            if (movementCoroutine != null)
            {
                StopCoroutine(movementCoroutine);
            }

            // Get the mouse position in world coordinates
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 29f;

            // Convert the mouse position to world coordinates
            targetPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            // Set the direction to move after reaching the mouse click position
            moveDirection = (targetPosition - transform.position).normalized;

            

            // Start moving towards the target position
            movementCoroutine = StartCoroutine(MoveToTarget());
        }
    }

    private System.Collections.IEnumerator MoveToTarget()
    {
        currentSpeed = initialSpeed;
        while (true)
        {
            // Move in the set direction with a slower speed
            transform.position += moveDirection * currentSpeed * Time.deltaTime;

            // Gradually slow down the ball
            currentSpeed *= decelerationFactor;

            if (currentSpeed <= 2)
            {
                break;
            }

            yield return null;
        }
        isMoving = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            moveDirection = Vector3.Reflect(moveDirection, collision.contacts[0].normal).normalized;
        }

        // Reflect the direction upon collision
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hole")
        {
            transform.position = dest.transform.position;
            currentSpeed = 0;
        }

    }
}
