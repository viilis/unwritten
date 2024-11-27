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
        //There's probably a better way to do this but I'm tired and annoyed so this will have to do
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
            TaskManager.canDoTasks = true;
            break;

            case 4:
            foreach (var line in ManagerDayLeft4)
            {
                dialogueText.text = line.text;
                dialogueBg.gameObject.SetActive(true);
                yield return new WaitForSecondsRealtime(line.duration);
                dialogueBg.gameObject.SetActive(false);
            }
            TaskManager.canDoTasks = true;
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
            break;
        }

    }
}

[System.Serializable]
public class SubtitleLine
{
    public string text;
    public float duration;
}

