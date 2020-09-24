/**
 * File from this tutorial: https://www.youtube.com/watch?v=j6_SMdWeGFI
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider backLeftWheel;
    public WheelCollider backRightWheel;

    public float maxSteerAngle = 30;
    public float motorForce = 50;

    private float horizontalInput;
    private float verticalInput;
    private float steeringAngle;

    private void Update()
    {

    }
}
