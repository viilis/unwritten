using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Extend with other interfaces what should utilize raycasting e.g. IShooting
public class Caster<T> where T : MonoBehaviour, IInteractable
{
    private Transform _transform;
    private float _interactionDistance = 2.0f;
    private LayerMask _mask;

    public Caster(LayerMask mask, Transform originSource, float interactionDistance)
    {
        _mask = mask;
        _transform = originSource;
        _interactionDistance = interactionDistance;
    }

    public T TryCast()
    {
        if (Physics.Raycast(_transform.position, _transform.forward, out RaycastHit raycastHit, _interactionDistance, _mask))
        {
            if (raycastHit.transform.TryGetComponent(out T component))
            {
                return component;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
}
