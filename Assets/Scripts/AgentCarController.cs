/**
 * @file AgentCarController.cs
 * @author Fabian Huber (fabian.hbr@eduge.ch)
 * @brief Contains the CarController class.
 * @version 1.1
 * @date 04.11.2020
 *
 * @copyright CFPT (c) 2020
 *
 */

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using Unity.MLAgents;
using UnityEngine.InputSystem;

/// <summary>
/// Tank controls for a car.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class AgentCarController : Agent
{
    public float accelerationSpeed = 0.5f;
    public float rotationSpeed = 1f;

    //private Inputs inputActions;
    private Rigidbody rb;

    public override void Initialize()
    {
        base.Initialize();
        //inputActions = new Inputs();
        rb = GetComponentInChildren<Rigidbody>();
    }

    //private void Awake()
    //{
    //    inputActions.Car.Steer.performed += ctx => horizontalInput = ctx.ReadValue<float>();
    //    inputActions.Car.Steer.canceled += ctx => horizontalInput = 0f;
    //    inputActions.Car.Accelerate.performed += ctx => verticalInput = ctx.ReadValue<float>();
    //    inputActions.Car.Accelerate.canceled += ctx => verticalInput = 0f;
    //}

    public override void OnActionReceived(float[] vectorAction)
    {
        Accelerate(vectorAction[1]);
        Turn(vectorAction[0]);
    }

    public override void Heuristic(float[] actionsOut)
    {
        float hAxis = 0f;
        if (Keyboard.current.aKey.isPressed)
        {
            hAxis = -1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            hAxis = 1f;
        }

        actionsOut[0] = hAxis;
        actionsOut[1] = Keyboard.current.wKey.isPressed ? 1f : 0f;
    }

    private void Accelerate(float input)
    {
        if (input != 0f)
        {
            Vector3 mov = transform.forward * input * accelerationSpeed;
            rb.velocity += mov;
        }
    }

    private void Turn(float input)
    {
        if (input != 0)
        {
            float rotation = input * rotationSpeed;
            rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles.x, rb.rotation.eulerAngles.y + rotation, rb.rotation.eulerAngles.z);
        }
    }
}
