using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private TMP_Text displayText;
    [SerializeField]
    private Transform audioPosition;
    [SerializeField]
    private AudioClip gameOverMusic;
    private AudioInLoop gameOverLoop;
    [Range(0f, 1f)]
    public float volume;
    private AsyncOperation op;
    [SerializeField]
    private GameObject diaryPrefab;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        restartButton.interactable = false;
        restartButton.onClick.AddListener(Restart);

        displayText.text = EventManager.gameOverText;
        gameOverLoop = new AudioInLoop(gameOverMusic, audioPosition, volume);
        gameOverLoop.StartPlaying();

        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        op = SceneManager.LoadSceneAsync(Daytimes.Menu);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            Debug.Log("Loading progress: " + (op.progress * 100) + " %");

            if (op.progress >= 0.9f)
            {
                restartButton.interactable = true;
            }
            yield return null;
        }
    }

    void Restart()
    {
        DayManager.Instance.daysLeft = 4;
        TaskManager.Instance.MorningReset();
        PlayerSanity.ResetSanity();
        EventManager.Instance.isGameOver = false;
        op.allowSceneActivation = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
