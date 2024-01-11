using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneDetectionManager : MonoBehaviour
{
    public GameObject poolTablePrefab; // Assign your pool table prefab in the Inspector.

    private void OnEnable()
    {
        ARPlaneManager planeManager = GetComponent<ARPlaneManager>();
        planeManager.planesChanged += OnPlanesChanged;
    }

    private void OnDisable()
    {
        ARPlaneManager planeManager = GetComponent<ARPlaneManager>();
        planeManager.planesChanged -= OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
      
        foreach (ARPlane plane in args.added)
        {
            // Spawn the pool table on top of the detected plane.
            SpawnPoolTableOnPlane(plane);
        }
    }

    private void SpawnPoolTableOnPlane(ARPlane plane)
    {
        // Instantiate the pool table prefab.
        GameObject poolTable = Instantiate(poolTablePrefab, plane.center, Quaternion.identity);

        // Adjust the pool table's position to align with the plane.
        Vector3 objectPosition = poolTable.transform.position;
        objectPosition.y = plane.center.y; // Place it exactly on the plane's center.
        poolTable.transform.position = objectPosition;


        // Make the pool table a child of the detected plane to follow its movements.
        poolTable.transform.parent = plane.transform;
    }
}
