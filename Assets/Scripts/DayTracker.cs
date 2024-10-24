using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DayTracker : Singleton<DayTracker>
{
    static int _dayNumber = 3;
    Scene scene;
    public TMP_Text _message;
    public void DailyMessage()
    {
        scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;

        //change this to whatever ends up being the name of the morning scene
        if(sceneName.Equals("test_level_1"))
        {
            _dayNumber--; 
        } 
        
        if(_dayNumber == 1)
        {
            _message.text = _dayNumber + " day until deadline";
        }
        else
        {
            _message.text = _dayNumber + " days until deadline";
        }
    }
}
