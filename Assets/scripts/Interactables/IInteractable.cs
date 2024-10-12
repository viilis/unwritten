using UnityEngine;

public interface IInteractable
{
    public Outline Outline { get; set; }
    public void Interact();
    public void ActionBeforeInteraction();
    public void UndoInteraction();
}