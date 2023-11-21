using System.Collections;
using UnityEngine;

public class Whiteballmove : MonoBehaviour
{
    private Camera mainCamera;
    public float speed = 5f; // Adjust the speed of movement
    public float zDistance = 29f; // Adjust the z-coordinate distance from the camera

    // Direction to move after reaching the mouse click position
    private Vector3 moveDirection;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = zDistance;
            Vector3 targetPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            // Set the direction to move after reaching the mouse click position
            moveDirection = (targetPosition - transform.position).normalized;

            StartCoroutine(MoveToTarget(targetPosition));
        }
    }

    private IEnumerator MoveToTarget(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        // Ensure the ball reaches the exact target position
        transform.position = targetPosition;

        // Continue moving in the set direction
        StartCoroutine(ContinuousMove());
    }

    private IEnumerator ContinuousMove()
    {
        while (true)
        {
            // Move in the set direction
            transform.position += moveDirection * speed * Time.deltaTime;

            yield return null;
        }
    }
}
