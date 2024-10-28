using UnityEngine;
using UnityEngine.InputSystem;

//TODO: Check if there is race conditions or something
public class InputManager : Singleton<InputManager>
{
    [SerializeField]
    private bool _debugMode = false;

    private PlayerControls _playerControls;

    // Actions
    private InputAction _interactAction;
    private InputAction _moveAction;
    private InputAction _lookAction;

    public override void Awake()
    {
        //FIXME: Does weird shit after one day cycle
        RemoveDuplicates();

        _playerControls = new PlayerControls();

        _interactAction = _playerControls.Gameplay.Interact;
        _moveAction = _playerControls.Gameplay.Move;
        _lookAction = _playerControls.Gameplay.Look;

        LockAndHideCursor();
    }

    private void Update()
    {
        if (_debugMode)
        {
            Debug.Log("MoveAction exists: " + _moveAction);
            Debug.Log("LookAction exists: " + _lookAction);
            Debug.Log("InteractAction exists: " + _interactAction);
        }
    }

    private void OnEnable()
    {
        _playerControls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        if (this.enabled)
        {
            _playerControls.Gameplay.Disable();
        }
    }

    // Locks cursor to application and hides it
    public void LockAndHideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // --- getters for actual input vectors
    public Vector2 GetRawMovementInput()
    {
        return _moveAction.ReadValue<Vector2>();
    }

    public Vector2 GetRawLookInput()
    {
        return _lookAction.ReadValue<Vector2>();
    }

    // getters for Actions
    public InputAction GetInteractAction()
    {
        return _interactAction;
    }

    public InputAction GetMovementAction()
    {
        return _moveAction;
    }
    public InputAction GetLookAction()
    {
        return _lookAction;
    }

    // Disablers and enablers
    public void DisableInteractButton()
    {
        _interactAction.Disable();
    }

    public void EnableInteractButton()
    {
        _interactAction.Enable();
    }

    public void DisableAllInputs()
    {
        if (debug)
        {
            Debug.Log("Disabled all inputs");
        }
        _playerControls.Gameplay.Disable();
    }

    public void EnableAllInputs()
    {
        if (debug)
        {
            Debug.Log("Enabled all inputs");
        }
        _playerControls.Gameplay.Enable();
    }
}