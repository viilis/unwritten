using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Dialogs/Dialog with audio")]
public class DialogBase : ScriptableObject
{
    public string dialogAuthor;
    public string dialogContent;

    public AudioClip audio;
}