using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallPhysics : MonoBehaviour
{
    public float force = 10f;
    void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRigidbody = collision.rigidbody;

        if (otherRigidbody != null)
        {
            // Calculate force based on collision
            Vector3 force = CalculateCollisionForce(collision);

            // Apply force to the other ball
            otherRigidbody.AddForce(force);
        }
    }

    Vector3 CalculateCollisionForce(Collision collision)
    {
        // Your custom logic to calculate the force based on collision

        // Example: Calculate force based on relative velocity
        float relativeVelocity = collision.relativeVelocity.magnitude;
        float forceMagnitude = relativeVelocity * force;

        // Example: Get the direction of the collision normal
        Vector3 forceDirection = collision.contacts[0].normal;

        // Calculate the force vector
        Vector3 calculatedForce = forceMagnitude * forceDirection;

        return calculatedForce;
    }
}
