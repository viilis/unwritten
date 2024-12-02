using UnityEngine;

[RequireComponent(typeof(Outline))]
public class DiaryPage : MonoBehaviour, IInteractable
{
    [SerializeField]
    private PageBase pageBase;

    private Outline _outline;
    private float _outlineWidth;

    public void Start()
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

        Debug.Log(pageBase.pageText.Substring(0, 10) + "...");
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    public void UndoBeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outline.OutlineWidth = 0f;
    }
}