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
    private int sanityTick;
    private int tempSanity;

    [SerializeField]
    [Tooltip("Can be used for calling events between x sec intervals. Defaults to 10 which translates to 5 seconds IRL time.")]
    private float eventInterval = 20f; // 10 seconds

    [SerializeField]
    private float level1Threshold = 70f;

    [SerializeField]
    private float level2Threshold = 50f;

    [SerializeField]
    private float level3Threshold = 20f;
    [SerializeReference]
    private float level4Threshold = 0f;

    private float _timer;
    public bool isGameOver = false;
    public static string gameOverText = null;

    private void OnEnable()
    {
        PlayerSanity.OnSanityChange += OnSanityChange;
    }

    public void EnableSanityTick()
    {
        sanityTick = tempSanity;
    }

    public void DisableSanityTick()
    {
        tempSanity = sanityTick;
        sanityTick = 0;
    }

    private void OnSanityChange(float currentSanity)
    {
        if (currentSanity <= level1Threshold)
        {
            Debug.Log("Level 1.");
            OnParanormalObjMovementEvent?.Invoke();
        }

        if (currentSanity <= level2Threshold)
        {
            Debug.Log("Level 2.");
            OnParanormalElectronicsEvent?.Invoke();
            OnParanormalDoorSlamEvent?.Invoke();
        }

        if (currentSanity <= level3Threshold)
        {
            Debug.Log("Level 3.");
            OnInternalVoicesEvent?.Invoke();
        }

        if (currentSanity <= level4Threshold)
        {
            Debug.Log("Game Over!!!!!");
            isGameOver = true;
            gameOverText = "you died oh no :(";
            StartCoroutine(DayManager.Instance.GoToNextScene(true));
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

            //decrease sanity by a set amount every time timer ticks down
            if (!isGameOver)
                PlayerSanity.ChangeSanity(sanityTick);
        }
    }

    private void OnDisable()
    {
        PlayerSanity.OnSanityChange -= OnSanityChange;
    }
}