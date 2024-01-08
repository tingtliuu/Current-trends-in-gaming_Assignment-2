using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBall2 : MonoBehaviour
{
    public float forceMultiplier = 10f;
    private Rigidbody rb;
    public GameObject dest;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 corresponds to the left mouse button
        {
            // Add force in the direction of the mouse position
            AddForceToBall();
        }
    }

    void AddForceToBall()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 29f;

        // Convert the mouse position to a ray in the game world
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        // Check if the ray hits something
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Calculate the direction from the ball to the mouse position
            Vector3 forceDirection = (hit.point - transform.position).normalized;

            // Apply force to the ball
            rb.AddForce(forceDirection * forceMultiplier, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hole")
        {
            transform.position = dest.transform.position;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

    }
}
