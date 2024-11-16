using UnityEngine;
using Unity;
using TMPro;

public class LoadingCanvas : Singleton<LoadingCanvas>
{
    // Makes Canvas singleton so that it wont be destroyed between scene loads. Scuffed but works.
    public CanvasGroup cg;

    [SerializeField]
    private TMP_Text deadLineTMP = null;

    [SerializeField]
    private TMP_Text dayTimeTMP = null;

    private void Start()
    {
        if (deadLineTMP == null || dayTimeTMP == null)
        {
            Debug.LogError("Missing loading canvas components");
        }
    }

    private void Update()
    {
        deadLineTMP.text = DayManager.Instance.GetDeadlineText();
        dayTimeTMP.text = DayManager.Instance.GetCurrentTimeState();
    }
}