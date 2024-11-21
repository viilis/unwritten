using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private TMP_Text displayText;

    void Start()
    {
        displayText.text = EventManager.gameOverText;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
