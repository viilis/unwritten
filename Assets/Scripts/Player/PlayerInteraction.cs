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

    // For inputs
    private PlayerControls _playerControls;
    private Transform _playerCamera;
    private InputAction _interactAction;
    private InputAction _lookAction;
    private InputAction _moveAction;

    private Caster<IInteractable> _iCaster;
    private IInteractable _obj;

    private void Awake()
    {
        _playerCamera = Camera.main.transform;
        _playerControls = new PlayerControls();

        _interactAction = _playerControls.Gameplay.Interact;
        _moveAction = _playerControls.Gameplay.Move;
        _lookAction = _playerControls.Gameplay.Look;
    }

    private void Start()
    {
        _iCaster = new Caster<IInteractable>(layerMask, _playerCamera, interactionDistance, true);
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
        _iCaster.GetHitComponent()?.Interact();
    }

    // Move these into Ingame ui thing
    private void OnLook(InputAction.CallbackContext context)
    {
        var result = _iCaster.GetHitComponent();
        OnSight(result);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        var result = _iCaster.GetHitComponent();
        OnSight(result);
    }

    private void OnSight(IInteractable castResult)
    {
        if (castResult != null)
        {
            if (_obj != castResult && _obj != null)
            {
                _obj.UndoBeforeInteraction();
            }

            _obj = castResult;
            _obj.BeforeInteraction();
        }
        else
        {
            if (_obj != null)
            {
                _obj.UndoBeforeInteraction();
                _obj = null;
            }
        }
    }
}
