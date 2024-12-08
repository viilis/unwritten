using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMan : MonoBehaviour
{
    private BoxCollider _tg;
    [SerializeField]
    private GameObject _shadowman;
    
    void Start()
    {
        _tg = GetComponent<BoxCollider>();
        _tg.isTrigger = true;
        _shadowman.SetActive(false);
    }

    public void OnTriggerEnter()
    {
        _shadowman.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.OnShadowManEvent += OnEventTrigger;
    }

    private void OnDisable()
    {
        EventManager.OnShadowManEvent -= OnEventTrigger;
    }    

    public void OnEventTrigger()
    {
        _shadowman.SetActive(true);
    }
}
