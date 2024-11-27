using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class Subtitles : MonoBehaviour
{

    //note to self: never write shit like this again

    public SubtitleLine[] ManagerDayLeft1;
    public SubtitleLine[] ManagerDayLeft2; 
    public SubtitleLine[] ManagerDayLeft3; 
    public SubtitleLine[] ManagerDayLeft4; 
    public SubtitleLine[] ManagerDayLeft5; 
    public SubtitleLine[] FriendCall; 

    public TMP_Text dialogueText;
    public Image dialogueBg;

    void Start()
    {
        dialogueBg.gameObject.SetActive(false);
    }

    public void StartManagerSubtitles()
    {
        StartCoroutine(ManagerSubtitleCoroutine());
    }

    IEnumerator ManagerSubtitleCoroutine()
    {
        switch(DayManager.Instance.daysLeft)
        {
            case 5:
            foreach (var line in ManagerDayLeft5)
            {
                dialogueText.text = line.text;
                dialogueBg.gameObject.SetActive(true);
                yield return new WaitForSecondsRealtime(line.duration);
                dialogueBg.gameObject.SetActive(false);
            }
            break;

            case 4:
            foreach (var line in ManagerDayLeft4)
            {
                dialogueText.text = line.text;
                dialogueBg.gameObject.SetActive(true);
                yield return new WaitForSecondsRealtime(line.duration);
                dialogueBg.gameObject.SetActive(false);
            }
            break;

            case 3:
            foreach (var line in ManagerDayLeft3)
            {
                dialogueText.text = line.text;
                dialogueBg.gameObject.SetActive(true);
                yield return new WaitForSecondsRealtime(line.duration);
                dialogueBg.gameObject.SetActive(false);
            }
            break;

            case 2:
            foreach (var line in ManagerDayLeft2)
            {
                dialogueText.text = line.text;
                dialogueBg.gameObject.SetActive(true);
                yield return new WaitForSecondsRealtime(line.duration);
                dialogueBg.gameObject.SetActive(false);
            }
            break;

            case 1:
            foreach (var line in ManagerDayLeft1)
            {
                dialogueText.text = line.text;
                dialogueBg.gameObject.SetActive(true);
                yield return new WaitForSecondsRealtime(line.duration);
                dialogueBg.gameObject.SetActive(false);
            }
            break;
        }

    }
}

[System.Serializable]
public class SubtitleLine
{
    public string text; // The subtitle text to display
    public float duration; // Duration (in seconds) for which this subtitle should be displayed
}

