using UnityEngine;
using Unity;

public class LoadingCanvas : Singleton<LoadingCanvas>
{
    // Makes Canvas singleton so that it wont be destroyed between scene loads. Scuffed but works.
    public CanvasGroup cg;
}