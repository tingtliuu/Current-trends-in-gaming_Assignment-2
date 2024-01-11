using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class BoardSpawning : MonoBehaviour
{
    [SerializeField] private GameObject prefabObject;

    private GameObject spawnedObject;
    private Vector2 touchPosition;
    private ARRaycastManager _arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private ARAnchorManager _anchorManager;
    private ARPlaneManager _planeManager;
    private bool isSpawned;


    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
        _anchorManager = GetComponent<ARAnchorManager>();
        _planeManager = GetComponent<ARPlaneManager>();
        isSpawned = false;

    }

    void Update()
    {

        if (Input.touchCount > 0 && isSpawned == false)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                touchPosition = touch.position;

            if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                ARRaycastHit nearest = hits[0];
                ARPlane plane;
                ARAnchor point;

                if (spawnedObject == null)
                    spawnedObject = Instantiate(prefabObject, hitPose.position, hitPose.rotation);
                else
                    spawnedObject.transform.position = hitPose.position;

                plane = _planeManager.GetPlane(nearest.trackableId);
                if (plane != null)
                {
                    point = _anchorManager.AttachAnchor(plane, nearest.pose);
                }
                else
                {
                    // Make sure the new GameObject has an ARAnchor component
                    point = spawnedObject.GetComponent<ARAnchor>();
                    if (point == null)
                    {
                        point = spawnedObject.AddComponent<ARAnchor>();
                    }

                }

                spawnedObject.transform.parent = point.transform;
                isSpawned = true;
            }

        }
    }
}