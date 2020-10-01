/**
 * @file CarController.cs
 * @author Fabian Huber (fabian.hbr@eduge.ch)
 * @brief Contains the CarController class.
 * Code from this tutorial : https://www.youtube.com/watch?v=j6_SMdWeGFI
 * @version 1.0
 * @date 01.10.2020
 *
 * @copyright CFPT (c) 2020
 *
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the movement of the car.
/// </summary>
public class CarController : MonoBehaviour
{
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider backLeftWheel;
    public WheelCollider backRightWheel;

    public Transform frontLeftTransform;
    public Transform frontRightTransform;
    public Transform backLeftTransform;
    public Transform backRightTransform;

    public float maxSteerAngle = 30;
    public float motorForce = 50;

    private float horizontalInput;
    private float verticalInput;
    private float steeringAngle;

    private Inputs inputActions;

    private void Awake()
    {
        inputActions = new Inputs();

        inputActions.Car.Steer.performed += ctx => horizontalInput = ctx.ReadValue<float>();
        inputActions.Car.Steer.canceled += ctx => horizontalInput = 0f;

        inputActions.Car.Accelerate.performed += ctx => verticalInput = ctx.ReadValue<float>();
        inputActions.Car.Accelerate.canceled += ctx => verticalInput = 0f;
    }

    private void FixedUpdate()
    {
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }

    /// <summary>
    /// Steers the car on the inputed direction.
    /// </summary>
    public void Steer()
    {
        steeringAngle = maxSteerAngle * horizontalInput;
        frontLeftWheel.steerAngle = steeringAngle;
        frontRightWheel.steerAngle = steeringAngle;
    }

    /// <summary>
    /// Accelerates the car.
    /// </summary>
    private void Accelerate()
    {
        frontLeftWheel.motorTorque = verticalInput * motorForce;
        frontRightWheel.motorTorque = verticalInput * motorForce;
    }

    /// <summary>
    /// Updates the position of the wheels.
    /// </summary>
    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontLeftWheel, frontLeftTransform);
        UpdateWheelPose(frontRightWheel, frontRightTransform);
        UpdateWheelPose(backLeftWheel, backLeftTransform);
        UpdateWheelPose(backRightWheel, backRightTransform);
    }

    private static void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        collider.GetWorldPose(out Vector3 pos, out Quaternion rot);

        transform.position = pos;
        transform.rotation = rot;
    }

    private void OnEnable()
    {
        inputActions.Car.Enable();
    }

    private void OnDisable()
    {
        inputActions.Car.Disable();
    }
}
