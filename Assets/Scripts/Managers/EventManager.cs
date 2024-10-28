using System;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public event Action OnParanormalElectronics;
    public event Action OnParanormalObjMovement;
    public event Action OnParanormalDoorKnock;
    public event Action OnInternalVoices;
    public event Action OnTalkingItems;
    public event Action OnParanormalDoorSlam;

    [SerializeField]
    [Tooltip("Can be used for calling events between x sec intervals. Defaults to 10 which translates to 5 seconds IRL time.")]
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
            OnParanormalObjMovement?.Invoke();
        }

        if (currentSanity <= level2Threshold)
        {
            Debug.Log("Level 2.");
            OnParanormalElectronics?.Invoke();
            OnParanormalDoorSlam?.Invoke();
        }

        if (currentSanity <= level3Threshold)
        {
            Debug.Log("Level 3.");
            OnInternalVoices?.Invoke();
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
            Debug.Log("Eventmanager -> invoked on interval" + eventInterval);
            _timer = eventInterval;
        }
    }

    private void OnDisable()
    {
        PlayerSanity.OnSanityChange -= OnSanityChange;
    }
}