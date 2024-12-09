using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodWriting : MonoBehaviour
{
    [SerializeField]
    private GameObject _bloodWriting;
    void Start()
    {
        _bloodWriting.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.OnBloodWritingEvent += OnEventTrigger;
    }

    private void OnDisable()
    {
        EventManager.OnBloodWritingEvent -= OnEventTrigger;
    }    

    public void OnEventTrigger()
    {
        _bloodWriting.SetActive(true);
    }
}
