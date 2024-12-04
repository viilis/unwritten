using Unity;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(menuName = "Diary/page")]
public class PageBase : ScriptableObject
{
    public string timeStamp;

    [TextArea(10, 1000)]
    public string pageText;

    public Texture2D image;

    public AudioClip interactFX;
}