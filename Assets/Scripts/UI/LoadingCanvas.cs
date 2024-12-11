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
    [SerializeField]
    private TMP_Text quoteTMP = null;

    private void Start()
    {
        if (deadLineTMP == null || dayTimeTMP == null)
        {
            Debug.LogError("Missing loading canvas components");
        }
    }

    void GetDeadlineTexts()
    {
        deadLineTMP.text = DayManager.Instance.GetDeadlineText();
        dayTimeTMP.text = DayManager.Instance.GetCurrentTimeState();  
    }

    private void Update()
    {
        if((DayManager.Instance.GetCurrentTimeState() == "endOfDay"))
        {
            deadLineTMP.text = null;
            dayTimeTMP.text = null;
            quoteTMP.text = null;
        }
        else
        {
            switch(DayManager.Instance.daysLeft)
            {
                case 4:
                    quoteTMP.text = "''Reality is merely an illusion, albeit a very persistent one.'' - Albert Einstein";
                    deadLineTMP.text = DayManager.Instance.GetDeadlineText();
                    dayTimeTMP.text = DayManager.Instance.GetCurrentTimeState(); 
                break;
                case 3:
                    quoteTMP.text = "''Beware the barrenness of a busy life.'' - Socrates";
                    deadLineTMP.text = DayManager.Instance.GetDeadlineText();
                    dayTimeTMP.text = DayManager.Instance.GetCurrentTimeState(); 
                break;
                case 2:
                    quoteTMP.text = "''The flame that burns twice as bright burns half as long.'' - Lao Tzu";
                    deadLineTMP.text = DayManager.Instance.GetDeadlineText();
                    dayTimeTMP.text = DayManager.Instance.GetCurrentTimeState(); 
                break;
                case 1:
                    quoteTMP.text = "''You can't pour from an empty cup.'' - Anonymous";
                    deadLineTMP.text = DayManager.Instance.GetDeadlineText();
                    dayTimeTMP.text = DayManager.Instance.GetCurrentTimeState(); 
                break;
                case 0:
                    quoteTMP.text = "''The bow kept forever taut will break.'' - Zen Proverb";
                    deadLineTMP.text = DayManager.Instance.GetDeadlineText();
                    dayTimeTMP.text = DayManager.Instance.GetCurrentTimeState(); 
                break;
                default:
                    if(DayManager.Instance.GetCurrentTimeState() == "goodEnding")
                    {
                        quoteTMP.text = "''In the end, we only regret the chances we didn't take.'' - Lewis Carroll";
                        deadLineTMP.text = "Day after deadline..";
                        dayTimeTMP.text = "Morning";   
                    }
                    else if(DayManager.Instance.GetCurrentTimeState() == "neutralEnding")
                    {
                        quoteTMP.text = "''In the end, we only regret the chances we didn't take.'' - Lewis Carroll";
                        deadLineTMP.text = "Finished, but at what cost?";
                        dayTimeTMP.text = "Morning";   
                    }
                    else if(DayManager.Instance.GetCurrentTimeState() == "gameOver")
                    {
                        deadLineTMP.text = null;
                        dayTimeTMP.text = null;   
                        quoteTMP.text = null;
                }
                break;
            }
        }
    }
}