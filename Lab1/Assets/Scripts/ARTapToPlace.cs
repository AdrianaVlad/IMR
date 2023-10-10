using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlace : MonoBehaviour
{
    public GameObject[] newCacti = new GameObject[2];

    public GameObject[] spawnedCacti = new GameObject[2];
    private int nextCactus = 0;
    private ARRaycastManager raycastManager;
    private Pose hitPose;
    private bool change;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            if (change == true)
            {
                if (spawnedCacti[nextCactus] == null)
                {
                    spawnedCacti[nextCactus] = Instantiate(newCacti[nextCactus], hitPose.position, hitPose.rotation);
                    nextCactus = (nextCactus + 1) % 2;
                }
                else
                {
                    spawnedCacti[nextCactus].transform.position = hitPose.position;
                    nextCactus = (nextCactus + 1) % 2;
                }
                change = false;
            }
            else 
                return;
        }
        if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            hitPose = hits[0].pose;
            change = true;
        }
    }
}
