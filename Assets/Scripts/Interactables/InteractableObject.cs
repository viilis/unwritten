using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline), typeof(SceneSwitcher))]
public class InteractableObject : MonoBehaviour, IInteractable
{
    private Outline _outline;

    [SerializeField]
    private bool isWorkTask;

    public void BeforeInteraction()
    {
        _outline.OutlineWidth = 5;
    }

    public void Interact()
    {
        _outline.OutlineWidth = 0;
        return;
    }

    public void UndoBeforeInteraction()
    {
        _outline.OutlineWidth = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineWidth = 0;
    }
}
