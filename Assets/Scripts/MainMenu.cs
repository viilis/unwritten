using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Transform audioPosition;
    [SerializeField]
    private AudioClip menuMusic;
    private AudioInLoop menuMusicLoop;
    [SerializeField]
    Slider volumeSlider;
    [Range(0f, 1f)]
    public float volume;

    private AsyncOperation op;

    void Start()
    {
        menuMusicLoop = new AudioInLoop(menuMusic, audioPosition, volume);
        menuMusicLoop.StartPlaying();

        playButton.interactable = false;
        playButton.onClick.AddListener(Play);

        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {

        op = SceneManager.LoadSceneAsync(Daytimes.Morning);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            Debug.Log("Loading progress: " + (op.progress * 100) + " %");

            if (op.progress >= 0.9f)
            {
                playButton.interactable = true;
            }
            yield return null;
        }
    }

    void Play()
    {
        op.allowSceneActivation = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
