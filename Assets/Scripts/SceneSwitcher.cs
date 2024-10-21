using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    FadeInOut fade;

    void Start()
    {
        fade = GetComponent<FadeInOut>();
    }

    public IEnumerator GoToNextScene(string sceneName)
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

}
