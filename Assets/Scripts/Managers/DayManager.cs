using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class DayManager : Singleton<DayManager>
{
    public int daysLeft = 5;
    private string dayMessage;

    [SerializeField]
    [Range(1, 10)]
    private float fadeDuration = 2f;

    private string _dt = Daytimes.Morning;
    private PlayerControls _playerControls;
    public float currentSanity;

    private void Start()
    {
        dayMessage = daysLeft + " days until deadline";

        // Start game by fading in(?)
        StartCoroutine(FadeLoadingScreen(0, fadeDuration));
    }

    private void Update()
    {
        currentSanity = PlayerSanity.GetSanity();
    }

    /// <summary>
    /// Goes to next day time (changes scene). Has simple state machine so function knows what daytime comes next.
    /// </summary>
    /// <returns>IEnumerator, MOST BE CALLED IN COROUTINE</returns>
    public IEnumerator GoToNextScene(bool isGameOver)
    {
        InputManager.Instance.DisableAllInputs();

        yield return StartCoroutine(FadeLoadingScreen(1, fadeDuration));

        AsyncOperation operation = null;

        //FIXME: Day counting logic might be broken but yeah, fix it here
        if(!isGameOver)
        {
            switch (_dt)
            {
                case Daytimes.Morning:
                    _dt = Daytimes.Afternoon;
                    operation = SceneManager.LoadSceneAsync(_dt);
                    break;

                case Daytimes.Afternoon:
                    _dt = Daytimes.Evening;
                    operation = SceneManager.LoadSceneAsync(_dt);
                    break;

                case Daytimes.Evening:
                    _dt = Daytimes.Night;
                    operation = SceneManager.LoadSceneAsync(_dt);
                    break;

                case Daytimes.Night:
                    // Day cycle done
                    daysLeft--;
                    
                    if (daysLeft == 1)
                    {
                        dayMessage = daysLeft + " day until deadline";
                    }
                    else
                    {
                        dayMessage = daysLeft + " days until deadline";
                    }

                    if (daysLeft < 0)
                    {
                        if(currentSanity > 70f)
                        {
                            EventManager.Instance.isGameOver = true;
                            _dt = Daytimes.GoodEnding;
                            operation = SceneManager.LoadSceneAsync(_dt);
                            break;
                        }
                        else if(currentSanity > 0f || currentSanity <= 70f)
                        {
                            EventManager.Instance.isGameOver = true;
                            _dt = Daytimes.NeutralEnding;
                            operation = SceneManager.LoadSceneAsync(_dt);
                            break;
                        }
                    }
                    _dt = Daytimes.Morning;
                    TaskManager.Instance.MorningReset();
                    operation = SceneManager.LoadSceneAsync(_dt);
                    break;

                default:
                    Debug.LogError("Invalid Daytime");
                    yield break;
            }
        }
        else
        {
            operation = SceneManager.LoadSceneAsync(Daytimes.GameOver);
        }

        // Loads next scene ready for launch in coroutine so that main thread (actual game) won't freeze. https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html
        if (operation != null)
        {
            operation.allowSceneActivation = false;

            while (!operation.isDone)
            {
                Debug.Log("Loading progress: " + (operation.progress * 100) + " %");

                // When 90% ready, new scene can be launched. https://docs.unity3d.com/ScriptReference/AsyncOperation-allowSceneActivation.html
                if (operation.progress >= 0.9f)
                {
                    // Launch new scene
                    InputManager.Instance.EnableAllInputs();

                    operation.allowSceneActivation = true;
                    yield return StartCoroutine(FadeLoadingScreen(0, fadeDuration));
                }

                yield return null;
            }
        }
    }

    /// <summary>
    /// Fade function that uses loading canvas
    /// </summary>
    /// <param name="targetValue"></param>
    /// <param name="duration"></param>
    /// <returns>IEnumerator, can be used for coroutines</returns>
    private IEnumerator FadeLoadingScreen(float targetValue, float duration)
    {
        float startValue = LoadingCanvas.Instance.cg.alpha;
        float time = 0;

        while (time < duration)
        {
            LoadingCanvas.Instance.cg.alpha = Mathf.Lerp(startValue, targetValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        LoadingCanvas.Instance.cg.alpha = targetValue;
    }

    public string GetDeadlineText()
    {
        return dayMessage;
    }

    public string GetCurrentTimeState()
    {
        return _dt;
    }
}


// scene names, must match scene names which are set in build settings. https://docs.unity3d.com/Manual/build-profile-scene-list.html
public static class Daytimes
{
    public const string Morning = "morning";
    public const string Afternoon = "afternoon";
    public const string Evening = "evening";
    public const string Night = "night";
    public const string GoodEnding = "goodEnding";
    public const string NeutralEnding = "neutralEnding";
    public const string GameOver = "gameOver";
}
