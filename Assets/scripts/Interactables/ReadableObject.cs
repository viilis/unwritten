using TMPro;
using UnityEngine;

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

        if (!dialogPanel.activeSelf)
        {
            dialogPanel.SetActive(true);
        }
    }

    public void UndoInteraction()
    {
        if (dialogPanel.activeSelf)
        {
            dialogPanel.SetActive(false);
        }
    }

    public void ActionBeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineVisible;
    }
}