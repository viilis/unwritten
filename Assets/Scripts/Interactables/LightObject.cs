using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObject : MonoBehaviour, IInteractable
{
    private Light _light;

    [SerializeField]
    private bool isOn;

    public void Interact()
    {
        Debug.Log("Interacted");
        _light.enabled = !_light.enabled;
    }

    public void BeforeInteraction()
    {
        return;
    }

    public void UndoBeforeInteraction()
    {
        return;
    }

    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
        if (isOn) { _light.enabled = true; } else { _light.enabled = false; };
    }
}
