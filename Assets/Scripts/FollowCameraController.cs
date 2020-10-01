using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraController : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;
    public float followSpeed = 10;
    public float lookSpeed = 10;

    /// <summary>
    /// Orients the camera in the direction to the car.
    /// </summary>
    private void LookAtTarget()
    {
        Vector3 lookDirection = objectToFollow.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, lookSpeed);

    }

    /// <summary>
    /// Moves the camera to the car.
    /// </summary>
    private void MoveToTarget()
    {
        Vector3 targetPos = objectToFollow.position +
            objectToFollow.forward * offset.z +
            objectToFollow.right * offset.x +
            objectToFollow.up * offset.y;
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed);
    }

    private void FixedUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }
}
