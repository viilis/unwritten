using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Extend with other interfaces what should utilize raycasting e.g. IShooting
public class Caster<T>
{
    private Transform _transform;
    private float _interactionDistance = 2.0f;
    private LayerMask _mask;

    private bool _debug = false;

    public Caster(LayerMask mask, Transform originSource, float interactionDistance)
    {
        _mask = mask;
        _transform = originSource;
        _interactionDistance = interactionDistance;
    }

    public Caster(LayerMask mask, Transform originSource, float interactionDistance, bool debug)
    {
        _mask = mask;
        _transform = originSource;
        _interactionDistance = interactionDistance;
        _debug = debug;
    }

    public T GetHitComponent()
    {
        if (_debug) { Debug.DrawRay(_transform.position, _transform.forward, Color.green, 2); };

        if (Physics.Raycast(_transform.position, _transform.forward, out RaycastHit raycastHit, _interactionDistance, _mask))
        {
            if (raycastHit.transform.TryGetComponent(out T component))
            {
                return component;
            }
            else
            {
                return default(T);
            }
        }
        else
        {
            return default(T);
        }
    }
}
