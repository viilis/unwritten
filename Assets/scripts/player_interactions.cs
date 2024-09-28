using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class player_interactions : MonoBehaviour
{
    // Player camera reference
    [SerializeField]
    private Transform playerCamera;

    [SerializeField]
    private float interactionDistance = 2f;

    [SerializeField]
    private LayerMask LayerMask;

    public GameObject canvas;

    CharacterController characterController;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Scuffed optimization: Prevents unwanted raycasting if player is not moving.
        if (!characterController.velocity.Equals(Vector3.zero) || !(Input.GetAxis("Mouse Y") + Input.GetAxis("Mouse X") == 0))
        {
            InteractionsFromSight();
        }
    }

    private void InteractionsFromSight()
    {
        //TODO: This raycast is calculated by every frame. May need optimization. For example: shoot raycast only if player moves and add debounce to that.
        Debug.Log("`InteractionsFromSight` raycast");
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hitItemInfo, interactionDistance, LayerMask))
        {
            // Read only objects
            if (hitItemInfo.transform.TryGetComponent(out readble_object readable))
            {
                var TMP = canvas.GetComponent<TMP_Text>();
                TMP.text = readable.GetReadableText().Length > 0 ? $"{readable.GetReadableText()}" : TMP.text;
                canvas.SetActive(true);
            }
        }
        else
        {
            canvas.SetActive(false);
        }
    }
}
