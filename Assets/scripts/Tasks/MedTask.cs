
using UnityEngine;

public class MedTask : SCTask, IInteractable
{
    private void Awake()
    {
        TaskManager.tasks.Add(this);
    }

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