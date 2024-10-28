using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RandomMovement : MonoBehaviour, IEvent
{
    private Rigidbody _rb;

    [SerializeField]
    private Vector3 forceVector;

    private void OnEnable()
    {
        EventManager.Instance.OnParanormalObjMovement += OnEventTrigger;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        EventManager.Instance.OnParanormalObjMovement -= OnEventTrigger;
    }

    public void OnEventTrigger()
    {
        _rb.AddForce(forceVector);
    }
}
