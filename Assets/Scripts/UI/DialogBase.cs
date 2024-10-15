using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Dialogs/Dialog with audio")]
public class DialogBase : ScriptableObject
{
    [SerializeField] public string dialogName { get; }
    [SerializeField] public string dialogDesc { get; }

    [SerializeField] public string dialogAuthor { get; }
    [SerializeField] public string dialogContent { get; }

    [SerializeField] public AudioClip audio { get; }
}