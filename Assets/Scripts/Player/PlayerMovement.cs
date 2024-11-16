using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 3f;

    [SerializeField]
    private float runSpeed = 4f;

    [SerializeField]
    private float gravity = 16f;

    private Vector3 moveDirection = Vector3.zero;

    private CharacterController _cc;

    private void Awake()
    {
        _cc = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 moveVec = InputManager.Instance.GetRawMovementInput();

        float curSpeedX = _cc.isGrounded ? runSpeed * moveVec.y : walkSpeed * moveVec.y;
        float curSpeedZ = _cc.isGrounded ? runSpeed * moveVec.x : walkSpeed * moveVec.x;

        float movementDirectionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * curSpeedX) + (transform.TransformDirection(Vector3.right) * curSpeedZ);

        if (!_cc.isGrounded)
        {
            moveDirection.y -= gravity;
        }

        _cc.Move(moveDirection * Time.deltaTime);
    }
}