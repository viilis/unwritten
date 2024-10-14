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

    private PlayerControls _playerControls;
    private InputAction _lookAction;

    private Camera _playerCamera;

    private void Start()
    {
        LockAndHideCursor();
    }

    private void Awake()
    {
        _playerCamera = GetComponentInChildren<Camera>();
        _playerControls = new PlayerControls();

        _lookAction = _playerControls.Gameplay.Look;
    }

    private void OnEnable()
    {
        _lookAction.Enable();
    }

    private void OnDisable()
    {
        _lookAction.Disable();
    }

    private void Update()
    {
        Vector2 mouseVec = _lookAction.ReadValue<Vector2>();

        rotationX += -mouseVec.y * lookSpeed;
        rotationX = Math.Clamp(rotationX, -lookLimit, lookLimit);

        _playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseVec.x * lookSpeed, 0);
    }

    public void LockAndHideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}