using TMPro;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class ReadableObject : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string readableText;

    [SerializeField]
    private GameObject dialogPanel;

    private Outline _outline;
    public Outline Outline { get => _outline; set => _outline = value; }

    private void Start()
    {
        _outline = GetComponent<Outline>();
    }

    public void Interact()
    {
        TMP_Text text = dialogPanel.transform.GetComponentInChildren<TMP_Text>();
        text.SetText(readableText);

        dialogPanel.SetActive(!dialogPanel.activeSelf);
    }

    public void BeforeInteraction()
    {
        Debug.Log("Before", this);
        _outline.OutlineMode = Outline.Mode.OutlineVisible;
    }

    public void UndoBeforeInteraction()
    {
        Debug.Log("Undo Before", this);
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
    }
}