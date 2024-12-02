using Unity;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Diary/page")]
public class PageBase : ScriptableObject
{
    public string timeStamp;
    [TextArea(10, 1000)]
    public string pageText;
}