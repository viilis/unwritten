using System;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public static event Action OnParanormalElectronicsEvent;
    public static event Action OnParanormalObjMovementEvent;

    [SerializeField]
    private float eventInterval = 5f; // 5 seconds

    private float _timer;

    private void Start()
    {
        _timer = eventInterval;
    }

    // Has timer logic if we want to invoke some events based on time interval after loading scene
    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            // Call action e.g OnParanormalElectronicsEvent?.Invoke();
            OnParanormalElectronicsEvent?.Invoke();
            OnParanormalObjMovementEvent?.Invoke();
            _timer = eventInterval;
        }
    }
}