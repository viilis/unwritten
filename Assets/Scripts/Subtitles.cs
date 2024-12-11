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
    public SubtitleLine[] KevEndingCall;

    public TMP_Text dialogueText;
    public Image dialogueBg;
    [SerializeField]
    private TMP_Text _callerName;

    [SerializeField]
    private TMP_Text dialogAuthor;

    void Start()
    {
        dialogueBg.gameObject.SetActive(false);
    }

    public void StartManagerSubtitles()
    {
        _callerName.text = "Manager";
        StartCoroutine(ManagerSubtitleCoroutine());
    }

    public void StartSituationalSubtitles()
    {
        if(DayManager.Instance.GetCurrentTimeState() == "evening")
        {
            _callerName.text = "Kev";
        }
        else
        {
            _callerName.text = "Kev";
        }
        StartCoroutine(SituationalSubtitles());
    }

    public void StartKevEndingCall()
    {
        _callerName.text = "Kev";
        StartCoroutine(KevEndingSubtitles());
    }

    IEnumerator ManagerSubtitleCoroutine()
    {
        switch (DayManager.Instance.daysLeft)
        {
            case 4:
                EventManager.Instance.sanityTickEnabled = false;
                foreach (var line in ManagerDayLeft4)
                {
                    dialogueText.text = line.text;
                    dialogAuthor.text = line.author;
                    dialogueBg.gameObject.SetActive(true);
                    yield return new WaitForSecondsRealtime(line.duration);
                    dialogueBg.gameObject.SetActive(false);
                }
                TaskManager.canDoTasks = true;
                EventManager.Instance.sanityTickEnabled = true;
                break;

            case 3:
                EventManager.Instance.sanityTickEnabled = false; 
                foreach (var line in ManagerDayLeft3)
                {
                    dialogueText.text = line.text;
                    dialogAuthor.text = line.author;
                    dialogueBg.gameObject.SetActive(true);
                    yield return new WaitForSecondsRealtime(line.duration);
                    dialogueBg.gameObject.SetActive(false);
                }
                TaskManager.canDoTasks = true;
                EventManager.Instance.sanityTickEnabled = true;
                break;

            case 2:
                EventManager.Instance.sanityTickEnabled = false;
                foreach (var line in ManagerDayLeft2)
                {
                    dialogueText.text = line.text;
                    dialogAuthor.text = line.author;
                    dialogueBg.gameObject.SetActive(true);
                    yield return new WaitForSecondsRealtime(line.duration);
                    dialogueBg.gameObject.SetActive(false);
                }
                TaskManager.canDoTasks = true;
                EventManager.Instance.sanityTickEnabled = true;
                break;

            case 1:
                EventManager.Instance.sanityTickEnabled = false;
                foreach (var line in ManagerDayLeft1)
                {
                    dialogueText.text = line.text;
                    dialogAuthor.text = line.author;
                    dialogueBg.gameObject.SetActive(true);
                    yield return new WaitForSecondsRealtime(line.duration);
                    dialogueBg.gameObject.SetActive(false);
                }
                TaskManager.canDoTasks = true;
                EventManager.Instance.sanityTickEnabled = true;
                break;

            case 0:
                EventManager.Instance.sanityTickEnabled = false;
                foreach (var line in ManagerDayLeft0)
                {
                    dialogueText.text = line.text;
                    dialogAuthor.text = line.author;
                    dialogueBg.gameObject.SetActive(true);
                    yield return new WaitForSecondsRealtime(line.duration);
                    dialogueBg.gameObject.SetActive(false);
                }
                TaskManager.canDoTasks = true;
                EventManager.Instance.sanityTickEnabled = true;
                break;
        }
    }

    IEnumerator SituationalSubtitles()
    {
        foreach (var line in SituationalCall)
        {
            dialogueText.text = line.text;
            dialogAuthor.text = line.author;
            dialogueBg.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(line.duration);
            dialogueBg.gameObject.SetActive(false);
        }
        TaskManager.canDoTasks = true;
        EventManager.Instance.sanityTickEnabled = true;
    }
    
    IEnumerator KevEndingSubtitles()
    {
        foreach (var line in KevEndingCall)
        {
            dialogueText.text = line.text;
            dialogAuthor.text = line.author;
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

// Shitty solution but works
    public string author;
    public float duration;
}

