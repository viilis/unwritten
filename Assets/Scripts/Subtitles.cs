using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class Subtitles : MonoBehaviour
{
    public SubtitleLine[] ManagerDayLeft0;
    public SubtitleLine[] ManagerDayLeft1;
    public SubtitleLine[] ManagerDayLeft2;
    public SubtitleLine[] ManagerDayLeft3;
    public SubtitleLine[] ManagerDayLeft4;
    public SubtitleLine[] SituationalCall;

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

    public void StartEndingSubtitles()
    {
        StartCoroutine(EndingSubtitles());
    }

    IEnumerator ManagerSubtitleCoroutine()
    {
        switch (DayManager.Instance.daysLeft)
        {
            case 4:
                foreach (var line in ManagerDayLeft4)
                {
                    dialogueText.text = line.text;
                    dialogueBg.gameObject.SetActive(true);
                    yield return new WaitForSecondsRealtime(line.duration);
                    dialogueBg.gameObject.SetActive(false);
                }
                TaskManager.canDoTasks = true;
                EventManager.Instance.sanityTickEnabled = true;
                break;

            case 3:
                foreach (var line in ManagerDayLeft3)
                {
                    dialogueText.text = line.text;
                    dialogueBg.gameObject.SetActive(true);
                    yield return new WaitForSecondsRealtime(line.duration);
                    dialogueBg.gameObject.SetActive(false);
                }
                TaskManager.canDoTasks = true;
                EventManager.Instance.sanityTickEnabled = true;
                break;

            case 2:
                foreach (var line in ManagerDayLeft2)
                {
                    dialogueText.text = line.text;
                    dialogueBg.gameObject.SetActive(true);
                    yield return new WaitForSecondsRealtime(line.duration);
                    dialogueBg.gameObject.SetActive(false);
                }
                TaskManager.canDoTasks = true;
                EventManager.Instance.sanityTickEnabled = true;
                break;

            case 1:
                foreach (var line in ManagerDayLeft1)
                {
                    dialogueText.text = line.text;
                    dialogueBg.gameObject.SetActive(true);
                    yield return new WaitForSecondsRealtime(line.duration);
                    dialogueBg.gameObject.SetActive(false);
                }
                TaskManager.canDoTasks = true;
                EventManager.Instance.sanityTickEnabled = true;
                break;

            case 0:
                foreach (var line in ManagerDayLeft0)
                {
                    dialogueText.text = line.text;
                    dialogueBg.gameObject.SetActive(true);
                    yield return new WaitForSecondsRealtime(line.duration);
                    dialogueBg.gameObject.SetActive(false);
                }
                TaskManager.canDoTasks = true;
                EventManager.Instance.sanityTickEnabled = true;
                break;
        }

    }

    IEnumerator EndingSubtitles()
    {
        foreach (var line in SituationalCall)
        {
            dialogueText.text = line.text;
            dialogueBg.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(line.duration);
            dialogueBg.gameObject.SetActive(false);
        }
    }
}

[System.Serializable]
public class SubtitleLine
{
    public string text;
    public float duration;
}

