using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityHitter : MonoBehaviour
{
    //Add this to an empty game object in each scene so that the sanity hit happens at the beginnig of each scene instead of the end
    void Start()
    {
        PlayerSanity.ChangeSanity(TaskManager._sanityHit);
        Debug.Log("Sanity hit with " + TaskManager._sanityHit);
    }
}
