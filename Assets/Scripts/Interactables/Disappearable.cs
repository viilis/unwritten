using UnityEngine;

public class Disappearable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private float delayTime = 2f;

    public void BeforeInteraction()
    {
        Invoke("Disappear", delayTime);
    }

    private void Disappear()
    {
        gameObject.SetActive(false);
    }

    public void Interact()
    {
        return;
    }

    public void UndoBeforeInteraction()
    {
        return;
    }
}

