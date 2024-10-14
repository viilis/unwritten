using UnityEngine;

public class MedTask : SCTask, IInteractable
{

    public void ActionBeforeInteraction()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        Complete();
    }

    public void UndoInteraction()
    {
        throw new System.NotImplementedException();
    }
}