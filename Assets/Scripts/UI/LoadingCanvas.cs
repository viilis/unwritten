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
        if(DayManager.Instance.daysLeft >= 0)
        {
            deadLineTMP.text = DayManager.Instance.GetDeadlineText();
            dayTimeTMP.text = DayManager.Instance.GetCurrentTimeState();           
        }
        else
        {
            if(DayManager.Instance.GetCurrentTimeState() == "goodEnding")
            {
                deadLineTMP.text = "good ending";
                dayTimeTMP.text = "yippiee!";   
            }
            else if(DayManager.Instance.GetCurrentTimeState() == "neutralEnding")
            {
                deadLineTMP.text = "neutral ending";
                dayTimeTMP.text = "oh ok";   
            }
        }

    }
}