using UnityEngine;

public class MedTask : SCTask, IInteractable
{

    public void Interact()
    {
        Complete();
    }

    public void Undo()
    {
        throw new System.NotImplementedException();
    }
}