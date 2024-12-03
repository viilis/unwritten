using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Transform audioPosition;
    [SerializeField]
    private AudioClip menuMusic;
    private AudioInLoop menuMusicLoop;
    [SerializeField]
    Slider volumeSlider;
    [Range(0f, 1f)]
    public float volume;

    void Start()
    {
        menuMusicLoop = new AudioInLoop(menuMusic, audioPosition, volume);
        menuMusicLoop.StartPlaying();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("morning");
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
