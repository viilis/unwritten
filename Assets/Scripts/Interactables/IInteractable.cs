using UnityEngine;

public interface IInteractable
{
    public void Interact();
    public void ActionBeforeInteraction();
    public void UndoInteraction();
}