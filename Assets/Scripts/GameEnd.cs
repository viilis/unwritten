using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public void EndGame()
    {
        if(DayManager.Instance.GetCurrentTimeState() == "neutralEnding")
        {
            EventManager.gameOverText = "You finished your work but you paid the price.\nTry to take it easier next time.";
            StartCoroutine(DayManager.Instance.GoToNextScene(true));
        }
        else if(DayManager.Instance.GetCurrentTimeState() == "goodEnding")
        {
            EventManager.gameOverText = "You might not have finished your book on time but you took care of your mental health.\nSometimes that's the right choice to make.";
            StartCoroutine(DayManager.Instance.GoToNextScene(true));
        }

    }
    public void SwitchScene()
    {
        StartCoroutine(DayManager.Instance.GoToNextScene(false));
    }
}
