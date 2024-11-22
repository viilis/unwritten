using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class GameOverTrigger : MonoBehaviour, IInteractable
{
    private Outline _outline;
    private float _outlineWidth;

    private void Start()
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
        EventManager.Instance.isGameOver = true;
        StartCoroutine(DayManager.Instance.GoToNextScene(true));
    }

    public void UndoBeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outline.OutlineWidth = 0f;
    }
}
