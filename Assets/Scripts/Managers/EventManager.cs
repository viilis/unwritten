using System;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public static event Action OnParanormalElectronicsEvent;
    public static event Action OnParanormalObjMovementEvent;
    public static event Action OnParanormalAudioEvent;
    public static event Action OnInternalVoicesEvent;
    public static event Action OnTalkingItemsEvent;
    public static event Action OnParanormalDoorSlamEvent;

    [SerializeField]
    private float eventInterval = 10f; // 5 seconds

    [SerializeField]
    private float level1Threshold = 70f;

    [SerializeField]
    private float level2Threshold = 50f;

    [SerializeField]
    private float level3Threshold = 20f;

    private float _timer;

    private void OnEnable()
    {
        PlayerSanity.OnSanityChange += OnSanityChange;
    }

    private void OnSanityChange(float currentSanity)
    {
        if (currentSanity <= level1Threshold)
        {
            Debug.Log("Level 1.");
            //OnParanormalObjMovementEvent?.Invoke();
            OnInternalVoicesEvent?.Invoke();
        }

        if (currentSanity <= level2Threshold)
        {
            Debug.Log("Level 2.");
            //OnParanormalElectronicsEvent?.Invoke();
        }

        if (currentSanity <= level3Threshold)
        {
            Debug.Log("Level 3.");
        }
    }

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
            // Call action e.g OnParanormalAudioEvent?.Invoke();
            Debug.Log("Invoked on interval" + eventInterval);
            _timer = eventInterval;
            OnParanormalDoorSlamEvent?.Invoke();
        }
    }

    private void OnDisable()
    {
        PlayerSanity.OnSanityChange -= OnSanityChange;
    }
}