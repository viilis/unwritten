using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouseLook : MonoBehaviour
{
    [SerializeField]
    private float lookSpeed = 0.1f;

    [SerializeField]
    private float lookLimit = 80f;

    private float rotationX = 0;

    private Camera _playerCamera;

    private void Awake()
    {
        _playerCamera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        Vector2 mouseVec = InputManager.Instance.GetRawLookInput();

        rotationX += -mouseVec.y * lookSpeed;
        rotationX = Math.Clamp(rotationX, -lookLimit, lookLimit);

        _playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseVec.x * lookSpeed, 0);
    }
}