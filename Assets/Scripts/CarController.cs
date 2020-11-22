/**
 * @file CarController.cs
 * @author Fabian Huber (fabian.hbr@eduge.ch)
 * @brief Contains the CarController class.
 * @version 1.1
 * @date 04.11.2020
 *
 * @copyright CFPT (c) 2020
 *
 */

using UnityEngine;

/// <summary>
/// Tank controls for a car.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    public const string FINISH_LINE_TAG = "End";

    public float accelerationSpeed = 0.5f;
    public float rotationSpeed = 3f;
    public GameObject winUI;

    private float horizontalInput;
    private float verticalInput;

    private Inputs inputActions;
    private Rigidbody rb;

    private void Awake()
    {
        inputActions = new Inputs();
        rb = GetComponentInChildren<Rigidbody>();

        inputActions.Car.Steer.performed += ctx => horizontalInput = ctx.ReadValue<float>();
        inputActions.Car.Steer.canceled += ctx => horizontalInput = 0f;

        inputActions.Car.Accelerate.performed += ctx => verticalInput = ctx.ReadValue<float>();
        inputActions.Car.Accelerate.canceled += ctx => verticalInput = 0f;
    }

    private void FixedUpdate()
    {
        Accelerate();
        Turn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(FINISH_LINE_TAG))
        {
            winUI.SetActive(true);
            enabled = false;
        }
    }

    /// <summary>
    /// Accelerates the car.
    /// </summary>
    private void Accelerate()
    {
        if (verticalInput != 0f)
        {
            Vector3 mov = transform.forward * verticalInput * accelerationSpeed;
            rb.velocity += mov;
        }
    }

    /// <summary>
    /// Turns the car.
    /// </summary>
    private void Turn()
    {
        if (horizontalInput != 0)
        {
            float rotation = horizontalInput * rotationSpeed;
            rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles.x, rb.rotation.eulerAngles.y + rotation, rb.rotation.eulerAngles.z);
        }
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}