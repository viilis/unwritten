using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    //don't know why this was deleted in the newest version, currently it's needed for the fade at the start of each scene
    //fadecontroller is perhaps a misleading name since the purpose is to fade the scene in at the start
    public DayTracker _dayTracker;
    FadeInOut fade;
    IEnumerator Start()
    {
        enabled = false;
        _dayTracker.DailyMessage();
        //wait time to be adjusted later, 
        //should be long enough for the player to be able to read whatever messages we want to put at the start
        yield return new WaitForSeconds(1);
        enabled = true;

        fade = GetComponent<FadeInOut>();
        fade.FadeOut();
    }

}
