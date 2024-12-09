using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Outline))]
public class CeilingLights : MonoBehaviour, IInteractable
{
    private Outline _outline;
    private float _outlineWidth;

    [SerializeField]
    private List<GameObject> lights;

    void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outlineWidth = _outline.OutlineWidth;

        //hide until first interaction;
        _outline.OutlineWidth = 0f;
    }

    public void BeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineVisible;
        _outline.OutlineWidth = _outlineWidth;
    }

    public void Interact()
    {
        foreach (GameObject light in lights)
        {
            if (light.TryGetComponent<Light>(out Light l))
            {
                light.SetActive(!light.activeInHierarchy);
            }
        }
    }

    public void UndoBeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outline.OutlineWidth = 0f;
    }
}
