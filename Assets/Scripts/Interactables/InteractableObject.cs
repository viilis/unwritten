using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline), typeof(SceneSwitcher))]
public class InteractableObject : MonoBehaviour, IInteractable
{
    private Outline _outline;
    private SceneSwitcher _sceneswitcher;
    public string sceneName;

    public void BeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineVisible;
    }

    public void Interact()
    {
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        StartCoroutine(_sceneswitcher.GoToNextScene(sceneName));
    }
    public void UndoBeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineHidden;

    }

    // Start is called before the first frame update
    void Start()
    {
        _sceneswitcher = GetComponent<SceneSwitcher>();
        _outline = GetComponent<Outline>();
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
    }

}
