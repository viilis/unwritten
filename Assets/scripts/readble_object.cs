using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class readble_object : MonoBehaviour
{
    [SerializeField]
    private string readableText;

    public string GetReadableText()
    {
        return readableText;
    }
}
