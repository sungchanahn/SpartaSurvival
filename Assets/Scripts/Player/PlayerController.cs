using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayerMask;
    private Vector2 curMovementInput;
    public float holdingTime;

    [Header("Look")]
    [SerializeField] private Transform cameraContainer;
    [SerializeField] private float minXLook;
    [SerializeField] private float maxXLook;
    [SerializeField] private float lookSensitivity;
    private float camCurXRot;
    private Vector2 mouseDelta;
    public bool CanLook = true;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        if (CanLook)
        {
            CameraLook();
        }
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;
        _rigidbody.velocity = dir;
    }
    private void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            if (context.duration < 0.2f)
            {
                holdingTime = 1f;
            }
            else
            {
                holdingTime = Mathf.Min((float)context.duration + 1f, 1.5f);
            }

            if (context.phase == InputActionPhase.Performed)
            {
                _rigidbody.AddForce(Vector2.up * jumpPower * holdingTime, ForceMode.Impulse);
            }
        }
    }

    public void OnGliding(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && !IsGrounded())
        {
            _rigidbody.drag = 15f;
        }
        else if (context.phase == InputActionPhase.Canceled || IsGrounded())
        {
            _rigidbody.drag = 0f;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    private bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (-transform.up * 0.19f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (-transform.up * 0.19f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (-transform.up * 0.19f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (-transform.up * 0.19f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }
}
