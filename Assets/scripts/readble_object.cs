using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class readble_object : MonoBehaviour
{
    [SerializeField]
    private string readableText;
    [SerializeField]
    private string interactionText;

    public string GetReadableText()
    {
        return readableText;
    }

    public string GetInteractionText()
    {
        return interactionText;
    }
}
