using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private float interactionDistance = 2f;

    [SerializeField]
    private LayerMask layerMask;

    private PlayerControls _playerControls;
    private Transform _playerCamera;
    private InputAction _interactAction;
    private InputAction _lookAction;
    private InputAction _moveAction;

    private ReadableObject obj;

    private Caster<ReadableObject> _readCaster;

    private void Awake()
    {
        _playerCamera = GetComponentInChildren<Transform>();
        _playerControls = new PlayerControls();

        _interactAction = _playerControls.Gameplay.Interact;
        _moveAction = _playerControls.Gameplay.Move;
        _lookAction = _playerControls.Gameplay.Look;
    }

    private void Start()
    {
        // Not really usable but good example
        _readCaster = new Caster<ReadableObject>(layerMask, _playerCamera, interactionDistance);
    }

    private void OnEnable()
    {
        _interactAction.Enable();
        _interactAction.performed += OnInteraction;

        _lookAction.Enable();
        _lookAction.performed += OnLook;

        _moveAction.Enable();
        _moveAction.performed += OnMove;

    }

    private void OnDisable()
    {
        _moveAction.performed -= OnMove;
        _moveAction.Disable();

        _lookAction.performed -= OnLook;
        _lookAction.Disable();

        _interactAction.performed -= OnInteraction;
        _interactAction.Disable();
    }


    private void OnInteraction(InputAction.CallbackContext context)
    {
        Debug.Log("OnInterAction");
        _readCaster.TryCast();
    }

    // Move these into Ingame ui thing
    private void OnLook(InputAction.CallbackContext context)
    {
        Debug.Log("OnLook");
        obj = _readCaster.TryCast();

        if (obj is not null)
        {
            obj.ActionBeforeInteraction();
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("OnMove");
        obj = _readCaster.TryCast();

        if (obj is not null)
        {
            obj.ActionBeforeInteraction();
        }
    }
}
