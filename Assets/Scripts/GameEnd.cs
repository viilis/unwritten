using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public void EndGame()
    {
        StartCoroutine(DayManager.Instance.GoToNextScene(true));
    }
}
